#include "Input.h"
#include "Game.h"
#include "Jass.h"
#include "Chat.h"
#include "Profile.h"
#include "string"
#include "GameStructs.h"
#define IsKeyPressed(CODE) ((GetKeyState(CODE) & 0x8000) > 0)
HWND Warcraft3Window = 0;
InputProc InputProc_ptr;
InputProc InputProc_org;
c_SimpleButtonClickEvent SimpleButtonClickEvent_org, SimpleButtonClickEvent_ptr;
pWc3ControlClickButton Wc3ControlClickButton_org, Wc3ControlClickButton_ptr;
#define N 27
int __fastcall SimpleButtonClickEvent_my(unsigned char* pButton, unsigned char* unused, int ClickEventType)
{
	return SimpleButtonClickEvent_ptr(pButton, unused, ClickEventType);
}
war3::CGameUI* GameUIObjectGet() {
	return *reinterpret_cast<war3::CGameUI**>(GameDll + 0xD326F0);
}
void War3ClickF1() {
	war3::CPortraitButton* PortraitButton = NULL;
	war3::CGameUI* PortraitButtonAddr = GameUIObjectGet();
	if (PortraitButtonAddr)
	{
		PortraitButton = PortraitButtonAddr->portraitButton;
	}
	Wc3ControlClickButton_org(PortraitButton, 1);
}
void JustClickMouse()
{
	BOOL ButtonDown = FALSE;
	if (IsKeyPressed(VK_LBUTTON))
	{
		ButtonDown = TRUE;
		SendMessage(Warcraft3Window, WM_LBUTTONUP, 0, 0);
	}

	INPUT Input = { 0 };
	Input.type = INPUT_MOUSE;
	Input.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
	SendInput(1, &Input, sizeof(INPUT));

	Input.type = INPUT_MOUSE;
	Input.mi.dwFlags = MOUSEEVENTF_LEFTUP;
	SendInput(1, &Input, sizeof(INPUT));

}
void War3ClickMouse() {
	POINT cursorhwnd;
	GetCursorPos(&cursorhwnd);
	ScreenToClient(Warcraft3Window, &cursorhwnd);

	InputProc_ptr(Warcraft3Window, WM_LBUTTONDOWN, MK_LBUTTON, MAKELPARAM(cursorhwnd.x, cursorhwnd.y));
	InputProc_ptr(Warcraft3Window, WM_LBUTTONUP, 0, MAKELPARAM(cursorhwnd.x, cursorhwnd.y));
}
/*

0	3	6	9
1	4	7	10
2	5	8	11

1	2
3	4
5	6

*/
int GetAltBtnID(int btnID)
{
	int altBtnIDs[] = { 0, 3, 6, 9, 1, 4, 7, 10, 2, 5, 8, 11, 0, 1, 2, 3, 4, 5 };

	if (btnID >= 0 && btnID < 18)
	{
		return altBtnIDs[btnID];
	}

	return -1;
}
bool IsNULLButtonFound(int pButton)
{
	if (pButton > 0 && *(int*)(pButton) > 0)
	{
		if (*(int*)(pButton + 0x190) != 0 && *(int*)(*(int*)(pButton + 0x190) + 4) == 0)
			return true;
	}
	return false;
}
unsigned char* CommandButtonVtable = (unsigned char*)GameDll + 0xAAD9B8;
int IsCommandButton(unsigned char* addr)
{
	if (addr)
	{
		if (CommandButtonVtable)
		{
			return *(unsigned char**)addr == CommandButtonVtable;
		}

	}
	return false;
}
#define flagsOffset 0x138
#define sizeOfCommandButtonObj 0x1c0

unsigned char* __stdcall GetSkillPanelButton(int idx)
{

	if (Jass::GetLocalSelect())
	{
		unsigned char* pclass = *(unsigned char**)(GameDll + 0xD326F0);
		if (pclass)
		{
			unsigned char* pGamePlayerPanelSkills = *(unsigned char**)(pclass + 0x3c8);
			if (pGamePlayerPanelSkills)
			{
				unsigned char* topLeftCommandButton = *(unsigned char**)(pGamePlayerPanelSkills + 0x154);
				if (topLeftCommandButton)
				{
					topLeftCommandButton = **(unsigned char***)(topLeftCommandButton + 0x8);
					if (topLeftCommandButton)
						return topLeftCommandButton + sizeOfCommandButtonObj * idx;
				}
			}
		}
	}
	return 0;
}

// | 0 | 1
// | 2 | 3
// | 4 | 5

unsigned char* __stdcall GetItemPanelButton(int idx)
{
	if (Jass::GetLocalSelect())
	{

		unsigned char* pclass = *(unsigned char**)(GameDll + 0xD326F0);
		if (pclass)
		{
			unsigned char* pGamePlayerPanelItems = *(unsigned char**)(pclass + 0x3c4);
			if (pGamePlayerPanelItems)
			{
				unsigned char* topLeftCommandButton = *(unsigned char**)(pGamePlayerPanelItems + 0x148);
				if (topLeftCommandButton)
				{
					topLeftCommandButton = *(unsigned char**)(topLeftCommandButton + 0x130);
					if (topLeftCommandButton)
					{
						topLeftCommandButton = *(unsigned char**)(topLeftCommandButton + 0x4);
						if (topLeftCommandButton)
						{
							return topLeftCommandButton + sizeOfCommandButtonObj * idx;
						}
					}
				}
			}
		}
	}
	return 0;
}
int PressSkillPanelButton(int idx, int RightClick)
{

	unsigned char* button = GetSkillPanelButton(idx);
	if (button && IsCommandButton(button))
	{
		unsigned int oldflag = *(unsigned int*)(button + flagsOffset);
		if (!(oldflag & 2))
			*(unsigned int*)(button + flagsOffset) = oldflag | 2;
		int retval = SimpleButtonClickEvent_org(button, 0, RightClick ? 4 : 1);
		*(unsigned int*)(button + flagsOffset) = oldflag;
		return retval;
	}
	return 0;
}

int PressItemPanelButton(int idx, int RightClick)
{

	unsigned char* button = GetItemPanelButton(idx);
	if (button && IsCommandButton(button))
	{
		unsigned int oldflag = *(unsigned int*)(button + flagsOffset);
		if (!(oldflag & 2))
			*(unsigned int*)(button + flagsOffset) = oldflag | 2;
		int retval = SimpleButtonClickEvent_org(button, 0, RightClick ? 4 : 1);
		*(unsigned int*)(button + flagsOffset) = oldflag;
		return retval;
	}
	return 0;
}
bool CheckBtnForQc(unsigned char* pButton) {
	int manacost;
	int unitmana;
	if (pButton && IsCommandButton(pButton))
	{
		if (*(int*)(pButton + 0x190))
		{
			int CommandButtonData = *(int*)(pButton + 0x190);
			const char* pAbilTitle = (const char*)(CommandButtonData + 0x2C);
			unsigned char* pAbil = *(unsigned char**)(CommandButtonData + 0x6D4);
			if (pAbil)
			{

				int pAbilId = *(int*)(pAbil + 0x34);
				if (pAbilId && (*(unsigned int*)(pButton + 0x140) & 16))
				{
					int pAbilData = *(int*)(pAbil + 0xDC);
					if (pAbilData)
					{
						float pAbilDataVal1 = *(float*)(pAbilData + 0x4);
						int pAbilDataVal2tmp = *(int*)(pAbilData + 0xC);
						if (pAbilDataVal1 > 0.0f && pAbilDataVal2tmp)
						{
							float pAbilDataVal2 = *(float*)(pAbilDataVal2tmp + 0x40);
							float AbilCooldown = pAbilDataVal1 - pAbilDataVal2;
							int AbilCooldownMinutes = (int)(AbilCooldown / 60.0f);
							int AbilCooldownSeconds = (int)((int)AbilCooldown % 60);
						}
						return false;
					}
					else
					{
						unitmana = Jass::GetUnitStat(Jass::GetLocalSelect(), Jass::UNIT_STAT_MP);
						manacost = Jass::GetAbilityManacost(pAbil);
						if (unitmana >= manacost)
							return true;
						else
						{
							return false;
						}

					}
				}
			}
		}
	}
	return false;
}
namespace Input {
	int QC[18];
	int isSelfClick[18];
	int isQC[18];
	int shop[12];
	bool skill_Enable;
	bool item_Enable;
	bool shop_Enable;
/*
0	3	6	9
1	4	7	10
2	5	8	11

1	2
3	4
5	6

*/
	void QC_HotkeysSetUp() {
		skill_Enable = ProfileFetchBool("Hotkey Skill", "Enable", true);
		item_Enable = ProfileFetchBool("Hotkey Item", "Enable", true);
		shop_Enable = ProfileFetchBool("Shop", "Enable", true);
		for (int i = 0; i < 12; i++)
		{
			QC[i] = ProfileFetchInt("Hotkey Skill", std::to_string(i).c_str(), 27);
			shop[i] = ProfileFetchInt("Shop", std::to_string(i).c_str(), 27);
		}
		for (int i = 12; i < 18; i++)
			QC[i] = ProfileFetchInt("Hotkey Item", std::to_string(i).c_str(), 27);
		for (int i = 0; i < 18; i++) {
			isSelfClick[i] = ProfileFetchBool("Self Click", std::to_string(i).c_str(), 0);
			isQC[i] = ProfileFetchBool("Quick Cast", std::to_string(i).c_str(), 0);
		}
			
	}
	int Shop(HWND hWnd, unsigned int& Msg, WPARAM& wParam, LPARAM& lParam) {
		if (Jass::GetLocalSelect()) {
			int unitid = Jass::GetUnitOwnerId(Jass::GetLocalSelect());
			if (!Jass::IsUnitType(Jass::GetLocalSelect(), Jass::UNIT_TYPE_HERO) && Jass::IsUnitType(Jass::GetLocalSelect(), Jass::UNIT_TYPE_INVUL)) {
				if (unitid == 0 || unitid == 4 || unitid == 8 || Jass::GetTypeId(Jass::GetLocalSelect()) == 'h0CN')
				{
					for (int i = 0; i < 12; i++) {
						if (wParam == shop[i] && shop[i] != 27) {
							PressSkillPanelButton(GetAltBtnID(i), 0);
							return 1;
						}
					}
				}
			}
		}
		return 0;
	}
	LRESULT __fastcall Input(HWND hWnd, unsigned int _Msg, WPARAM _wParam, LPARAM lParam)
	{
		unsigned int Msg = _Msg;
		WPARAM wParam = _wParam;
		//Chat
		{
			Warcraft3Window = hWnd;
		}

		if (Game::IsInGame() && Game::IsWindowActive())
		{
			if (wParam == VK_RETURN && Msg == WM_KEYDOWN)
			{
				if (Chat::CheckChat(hWnd, _Msg, _wParam, lParam) == 1)
				{
					return DefWindowProc(hWnd, _Msg, _wParam, lParam);
				}

			}
			if (Msg == WM_KEYDOWN)
			{
				if ((Shop(hWnd, _Msg, _wParam, lParam) == 1) && (shop_Enable==true))
				{
					return DefWindowProc(hWnd, _Msg, _wParam, lParam);
				}

			}
		}
		//QuickCast
		if (Game::IsInGame() && !Game::IsChat() && Game::IsWindowActive() && Jass::GetLocalPlayer()) {
			bool NeedSkip = false;
			if (Msg == WM_KEYDOWN || Msg == WM_XBUTTONDOWN || Msg == WM_MBUTTONDOWN ||
				Msg == WM_SYSKEYDOWN)
			{
				if (_Msg == WM_XBUTTONDOWN)
				{
					Msg = WM_KEYDOWN;
					wParam = _wParam & MK_XBUTTON1 ? VK_XBUTTON1 : VK_XBUTTON2;
				}

				if (_Msg == WM_MBUTTONDOWN)
				{
					Msg = WM_KEYDOWN;
					wParam = VK_MBUTTON;
				}
				//QC
				if (skill_Enable == true) {

				}
				for (int i = 0; i < 18; i++) {
					if (wParam == QC[i] && QC[i]!=27)
					{
						if (i < 12)
						{
							int btnid = GetAltBtnID(i);
							if (CheckBtnForQc(GetSkillPanelButton(btnid)) && skill_Enable==true) {
								PressSkillPanelButton(btnid, 0);
								if (isQC[i]==1)
									JustClickMouse();
								if (isSelfClick[i] == 1)
									War3ClickF1();
								NeedSkip = true;
							}
						}
						else if (!(lParam & 0x40000000))
						{
							int btnid = GetAltBtnID(i);
							if (CheckBtnForQc(GetItemPanelButton(btnid)) && item_Enable==true) {
								PressItemPanelButton(btnid, 0);
								if (isQC[i]==1)
									JustClickMouse();
								if (isSelfClick[i] == 1)
									War3ClickF1();
								NeedSkip = true;
							}
						}	
					}
				}
				//
				if (_Msg == WM_XBUTTONDOWN || _Msg == WM_MBUTTONDOWN)
				{
					Msg = _Msg;
					wParam = _wParam;
				}
			}
			if (NeedSkip)
				return DefWindowProc(hWnd, Msg, wParam, lParam);
		}
		return InputProc_ptr(hWnd, Msg, wParam, lParam);
	}
	int __fastcall Wc3ControlClickButton_my(void* btnaddr, int, int unk)
	{
		int retval = Wc3ControlClickButton_ptr(btnaddr, unk);
		return retval;
	}
	void Init() {
		InputProc_org = (InputProc)(GameDll + 0x0BAD40);
		MH_CreateHook(InputProc_org, &Input, reinterpret_cast<void**>(&InputProc_ptr));
		MH_EnableHook(InputProc_org);

		SimpleButtonClickEvent_org = (c_SimpleButtonClickEvent)(GameDll + 0x13D7F0);
		MH_CreateHook(SimpleButtonClickEvent_org, &SimpleButtonClickEvent_my, reinterpret_cast<void**>(&SimpleButtonClickEvent_ptr));
		MH_EnableHook(SimpleButtonClickEvent_org);

		Wc3ControlClickButton_org = (pWc3ControlClickButton)(GameDll + 0x1407B0);
		MH_CreateHook(Wc3ControlClickButton_org, &Wc3ControlClickButton_my, reinterpret_cast<void**>(&Wc3ControlClickButton_ptr));
		MH_EnableHook(Wc3ControlClickButton_org);

		QC_HotkeysSetUp();
	}
}
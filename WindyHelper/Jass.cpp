#include "Jass.h"
#include "Game.h"
#include "GameStructs.h"
#include "JassStructs.h"
#include "StringStructs.h"
#include <algorithm>
namespace Jass {
	p_GetPlayerName pGetPlayerName;
	p_GetTypeInfoAddr GetTypeIdInfoAddr;
	pGetUnitAbility GetUnitAbility;
	p_GetUnitLevel pGetUnitLevel;
	bool IsOkayPtr(void* ptr, unsigned int size)
	{
		bool returnvalue = false;
		returnvalue = IsBadReadPtr(ptr, size) == 0;
		return returnvalue;
	}
	BOOL IsNotBadUnit(unsigned char* unitaddr)
	{
		if (unitaddr)
		{
			int xaddr = GameDll + 0xB68914;
			int xaddraddr = (int)&xaddr;
			if (*(BYTE*)xaddraddr != *(BYTE*)unitaddr)
			{
				return FALSE;
			}
			else if (*(BYTE*)(xaddraddr + 1) != *(BYTE*)(unitaddr + 1))
			{
				return FALSE;
			}
			else if (*(BYTE*)(xaddraddr + 2) != *(BYTE*)(unitaddr + 2))
			{
				return FALSE;
			}
			else if (*(BYTE*)(xaddraddr + 3) != *(BYTE*)(unitaddr + 3))
			{
				return FALSE;
			}
			unsigned int isdolbany = *(unsigned int*)(unitaddr + 0x5C);
			BOOL returnvalue = (isdolbany != 0x1001u && (isdolbany & 0x40000000u) == 0 && !IsUnitType(unitaddr,UNIT_TYPE_DEAD));
			return returnvalue;
		}

		return FALSE;
	}
	void Init() {
		GetTypeIdInfoAddr = (p_GetTypeInfoAddr)(GameDll + 0x378720);
		pGetPlayerName = (p_GetPlayerName)(GameDll + 0x3A0F00);
		GetUnitAbility = (pGetUnitAbility)(GameDll + 0x4C0C90);
		pGetUnitLevel = (p_GetUnitLevel)(GameDll + 0x6B92E0);
	}
	char* GetPlayerName(PlayerID id) {
		return pGetPlayerName(id, 0);
	}
	char* IdToChar(int u_or_abi) {
		char id[5] = { 0 };
		CopyMemory(id, (LPVOID)(u_or_abi + 0x30), 4);
		return id;
	}
	bool IsUnitType(unit u, unittype type) {
		if (type == UNIT_TYPE_HERO) {
			if (u)
			{
				unsigned int ishero = *(unsigned int*)(u + 48);
				ishero = ishero >> 24;
				ishero = ishero - 64;
				return ishero < 0x19;
			}
			return false;
		}
		if (type == UNIT_TYPE_DEAD) {
			unsigned int isdolbany = *(unsigned int*)(u + 0x5C);
			BOOL UnitNotDead = ((isdolbany & 0x100u) == 0);
			return UnitNotDead == false;
		}
		if (type == UNIT_TYPE_INVUL) {
			if (GetUnitAbilityLevel(u, 'Avul') == 1)
				return true;
			else
				return false;
		}
		return false;
	}

	int GetObjectClassID(int unit_or_item_addr)
	{
		if (unit_or_item_addr)
			return *(int*)(unit_or_item_addr + 0x30);
		return 0;
	}

	const char* GetObjectNameByID(int clid)
	{

		if (clid > 0)
		{
			int v3 = GetTypeIdInfoAddr(clid, 0);
			int v4, v5;
			if (v3 && (v4 = *(int*)(v3 + 40)) != 0)
			{
				v5 = v4 - 1;
				if (v5 < 0)
					v5 = 0;
				return (char*)*(int*)(*(int*)(v3 + 44) + 4 * v5);
			}
			else
			{
				return "DefaultString";
			}
		}
		return "DefaultString";
	}

	const char* GetObjectName(unit objaddress)
	{
		return GetObjectNameByID(GetObjectClassID((int)objaddress));
	}
	char* GetTypeChar(unsigned char* unit_item_abil_etc_addr)
	{
		if (unit_item_abil_etc_addr)
		{
			char id[5] = { 0 };
			CopyMemory(id, (LPVOID)(unit_item_abil_etc_addr + 0x30), 4);
			std::reverse(id, id + 4);
			return id;
		}
		else
			return "null";
	}
	int GetTypeId(unsigned char* unit_item_abil_etc_addr)
	{
		if (unit_item_abil_etc_addr)
			return *(int*)(unit_item_abil_etc_addr + 0x30);
		else
			return 0;
	}
	int Player(int number)
	{
		int arg1 = Game::GetGlobalPlayerData();
		int result = 0;

		if (number < 0 || number > 15)
		{
			return 0;
		}

		if (arg1 > NULL)
		{
			result = (int)arg1 + (number * 4) + 0x58;

			if (result)
			{
				result = *(int*)result;
			}
			else
			{
				return 0;
			}
		}
		return result;
	}
	int GetLocalPlayer()
	{
		int gldata = Game::GetGlobalPlayerData();
		if (gldata > 0)
		{
			short retval = *(short*)(gldata + 0x28);
			return retval;
		}
		return 0;
	}
	int GetLocalPlayerId()
	{
		int gldata = Game::GetGlobalPlayerData();
		if (gldata > 0)
		{
			int playerslotaddr = (int)gldata + 0x28;
			if (IsOkayPtr((void*)playerslotaddr))
				return (int)*(short*)(playerslotaddr);
			else
				return -2;
		}
		else
			return -2;
	}
	unit GetPlayerSelect(PlayerID id)
	{
		int plr = Player(id);
		if (plr > 0)
		{
			int PlayerData1 = *(int*)(plr + 0x34);
			if (PlayerData1 > 0)
			{
				return *(unsigned char**)(PlayerData1 + 0x1e0);
			}
		}
		return NULL;
	}
	unit GetLocalSelect()
	{
		int plr = Player(GetLocalPlayer());
		if (plr > 0)
		{
			int PlayerData1 = *(int*)(plr + 0x34);
			if (PlayerData1 > 0)
			{
				return *(unsigned char**)(PlayerData1 + 0x1e0);
			}
		}
		return NULL;
	}
	int GetUnitAbilityLevel(unsigned char* unitaddr, int id, BOOL checkavaiable, BOOL CheckMemAccess)
	{
		if (CheckMemAccess)
			if (!IsNotBadUnit(unitaddr))
				return 0;

		void* abiladdr = (void*)GetUnitAbility(unitaddr, 0, id, 0, 1, 1, 1);
		if (abiladdr == nullptr || abiladdr == nullptr || !IsOkayPtr((void*)abiladdr))
			return 0;

		int abilleveladdr = (int)abiladdr + 80;
		int abilavaiable = (int)abiladdr + 32;
		if (checkavaiable)
		{
			if (IsOkayPtr((void*)abilavaiable))
			{
				unsigned int avaiableflag = *(unsigned int*)(abilavaiable);
				if (avaiableflag & 0x8000)
					return 0;
				if (IsOkayPtr((void*)abilleveladdr))
					return *(int*)(abilleveladdr)+1;
				else
					return 0;
			}
			else
				return 0;
		}
		else
		{
			if (IsOkayPtr((void*)abilleveladdr))
				return *(int*)(abilleveladdr)+1;
			else
				return 0;
		}

	}
	float GetUnitStat(unit unitaddr, unitstat statNum)
	{
		int _GetFloatStat = GameDll + 0x6BB400;
		float result = 0;
		__asm
		{
			PUSH statNum;
			LEA EAX, result;
			PUSH EAX;
			MOV ECX, unitaddr;
			CALL _GetFloatStat;
		}
		return result;
	}
	int GetAbilityManacost(unsigned char* pAbil)
	{
		if (pAbil)
		{
			int vtable = *(int*)pAbil;
			if (vtable)
			{
				int GetAbilMPcostAddr = *(int*)(vtable + 0x3d4);
				if (GetAbilMPcostAddr)
				{
					auto GetAbilMPcost = (int(__thiscall*)(unsigned char*))(GetAbilMPcostAddr);
					return GetAbilMPcost(pAbil);
				}
			}
		}
		return 0;
	}
	float GetUnitX(unit u) {
		return *(float*)(0x284 + u);
	}
	float GetUnitY(unit u) {
		return *(float*)(0x288 + u);
	}
	int GetUnitLevel(unit u) {
		return pGetUnitLevel(u,0);
	}
	int GetHeroMAXEXP(unsigned char* unit)
	{
		int exp = 0;
		for (int i = 1; i < GetUnitLevel(unit) + 1; ++i) {
			exp = exp + 100 * (i + 1);
		}
		return exp;
	}
	int __stdcall GetUnitOwnerId(unit unitaddr)
	{
		if (unitaddr)
			return *(int*)(unitaddr + 88);
		return 15;
	}
	bool IsAbilityCooldown(unsigned char* unitaddr, int id)
	{
		void* abiladdr = GetUnitAbility(unitaddr, 0, id, 0, 1, 1, 1);
		if (abiladdr == nullptr || abiladdr == nullptr || !IsOkayPtr((void*)abiladdr))
			return -1;

		int avilityflag = (int)abiladdr + 32;
		if (IsOkayPtr((void*)avilityflag))
		{
			unsigned int  state = *(unsigned int*)(avilityflag);
			return state & 0x200;
		}
		else
			return -1;
	}
	int* GetUnitCountAndUnitArray(unsigned char*** unitarray)
	{
		int GlobalClassOffset = *(int*)(GameDll + 0xD326F0);//WarcraftGlobalClassOffset
		if (GlobalClassOffset)
		{
			int UnitsOffset1 = *(int*)(GlobalClassOffset + 0x3BC);
			if (UnitsOffset1)
			{
				int* UnitsCount = (int*)(UnitsOffset1 + 0x604);
				if (*UnitsCount > 0)
				{
					*unitarray = (unsigned char**)*(int*)(UnitsOffset1 + 0x608);
					return UnitsCount;
				}
			}
		}
		*unitarray = 0;
		return 0;
	}
}
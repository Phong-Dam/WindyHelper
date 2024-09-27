#include "Init.h"
#include "Game.h"
#include "Input.h"
#include "Jass.h"
#include "Button.h"
#include "Chat.h"
#include "Profile.h"
#include "string"
DWORD WarcraftVersion()
{
	DWORD dwHandle = NULL;
	DWORD dwLen = GetFileVersionInfoSize("Game.dll", &dwHandle);

	LPVOID lpData = new char[dwLen];
	GetFileVersionInfo("Game.dll", dwHandle, dwLen, lpData);

	LPBYTE lpBuffer = NULL;
	UINT   uLen = NULL;
	VerQueryValue(lpData, "\\", (LPVOID*)&lpBuffer, &uLen);

	VS_FIXEDFILEINFO* Version = (VS_FIXEDFILEINFO*)lpBuffer;

	return LOWORD(Version->dwFileVersionLS);
}
DWORD WINAPI hamChayLienTuc(LPVOID lpParam)
{
	while (true) 
	{
		Input::QC_HotkeysSetUp();
		Sleep(500);
	}
	return 0;
}
HRESULT __stdcall DllMain(HMODULE _hModule, DWORD dwReason, LPVOID lpReserved)
{
	if (dwReason == DLL_PROCESS_ATTACH)
	{	
		if (WarcraftVersion() == 7680)
		{
			DWORD dwThread;
			MH_Initialize();
			//Init
			InitFile(_hModule);
			Game::Init();
			Input::Init();
			Jass::Init();
			Button::Init();
			Chat::Init();
			HANDLE hThread = CreateThread(NULL,0,hamChayLienTuc,NULL,0,NULL);

			//
		}
		
	}
		
	return 1;
}



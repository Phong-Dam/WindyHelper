#include "Game.h"
GAME_GetPtrList_t* GAME_GetPtrList = 0;
GAME_Print_t* GAME_Print = 0;
namespace Game {
	void Init() {
		GAME_GetPtrList = (GAME_GetPtrList_t*)(GameDll + 0x11BD30);
		GAME_Print = (GAME_Print_t*)(GameDll + 0x144480);
	}
	bool IsInGame() {
		return *(int*)(GameDll + 0xD328D0) > 0 || *(int*)(GameDll + 0xD30110) > 0;
	}
	bool IsWindowActive()
	{
		return *(bool*)(GameDll + 0xCA3E74);
	}
	int GetGlobalPlayerData()
	{
		return  *(int*)(0xD305E0 + GameDll);
	}

	void PrintText(const char* message, float stayUpTime)
	{
		if (IsInGame())
		{
			DWORD ptrList = GAME_GetPtrList();
			if (ptrList)
			{
				static DWORD color = 0xFFFFFFFF;
				GAME_Print(*((DWORD*)(ptrList + 0x3EC)), ptrList, message, &color, *((DWORD*)&stayUpTime), NULL);
			}

		}
	}
	bool IsChat()
	{
		return*(bool*)(GameDll + 0xD04FEC);
	}
	void PrintTextFormat(const char* format, ...)
	{
		if (IsInGame())
		{
			char str[8192] = { 0 };
			va_list args;
			va_start(args, format);
			vsprintf_s(str, sizeof(str), format, args);
			va_end(args);
			PrintText(str, 1);
		}
	}
}
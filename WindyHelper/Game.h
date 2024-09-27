#pragma once
#include "Init.h"
typedef DWORD __fastcall GAME_GetPtrList_t(VOID);
extern GAME_GetPtrList_t* GAME_GetPtrList;
typedef void __fastcall GAME_Print_t(DWORD ptrList, DWORD _EDX, const CHAR* text, DWORD* color, DWORD stayUpTime, DWORD _1);
extern GAME_Print_t* GAME_Print;
namespace Game {
	void Init();
	bool IsInGame();
	bool IsChat();
	bool IsWindowActive();
	void PrintText(const char* message, float stayUpTime=1);
	void PrintTextFormat(const char* format, ...);

	int GetGlobalPlayerData();
}
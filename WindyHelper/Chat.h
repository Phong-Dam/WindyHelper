#pragma once
#include "Init.h"
#include "Game.h"
typedef int(__fastcall* pGameChatSetState)(unsigned char* chat, int unused, int IsOpened);
extern pGameChatSetState GameChatSetState;
namespace Chat {
	void Init();
	int CheckChat(HWND hWnd, unsigned int& Msg, WPARAM& wParam, LPARAM& lParam);
}
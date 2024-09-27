#include "Chat.h"
pGameChatSetState GameChatSetState;
namespace Chat {
	void Init() {
		GameChatSetState = (pGameChatSetState)(GameDll + 0x3E3890);
	}
	unsigned char* GetChatOffset()
	{
		unsigned char* pclass = *(unsigned char**)(GameDll + 0xD326F0);
		if (pclass)
		{
			return *(unsigned char**)(pclass + 0x3FC);
		}

		return 0;
	}
	char* GetChatString()
	{
		unsigned char* pChatOffset = GetChatOffset();
		if (pChatOffset)
		{
			pChatOffset = *(unsigned char**)(pChatOffset + 0x1E0);
			if (pChatOffset)
			{
				pChatOffset = *(unsigned char**)(pChatOffset + 0x1E4);
				return (char*)pChatOffset;
			}
		}
		return 0;
	}
	int CheckChat(HWND hWnd, unsigned int& Msg, WPARAM& wParam, LPARAM& lParam)
	{
		bool Chat = false;
		unsigned char* ChatOffset = GetChatOffset();
		if (!ChatOffset)
		{
			return 0;
		}
		char* pChatString = GetChatString();
		if (!pChatString)
		{
			return 0;
		}
		if (VK_RETURN == (int)wParam && !(lParam & 0x40000000))
		{
			if (Game::IsChat())
			{
				if (strcmp(pChatString, "@test") == 0)
				{
					Game::PrintText("Test");
					Chat = true;
				}
				if (Chat == true)
				{
					GameChatSetState(ChatOffset, 0, 0);
					return 1;
				}
			}
		}

		return 0;
	}
}
#pragma once
#include "Init.h"
typedef LRESULT(__fastcall* InputProc)(HWND hWnd, unsigned int Msg, WPARAM wParam, LPARAM lParam);
extern InputProc InputProc_ptr;
extern InputProc InputProc_org;
typedef int(__fastcall* c_SimpleButtonClickEvent)(unsigned char* pButton, unsigned char* unused, int ClickEventType);
extern c_SimpleButtonClickEvent SimpleButtonClickEvent_org, SimpleButtonClickEvent_ptr;
typedef int(__thiscall* pWc3ControlClickButton)(void* btnaddr, int unk);
extern pWc3ControlClickButton Wc3ControlClickButton_org, Wc3ControlClickButton_ptr;
namespace Input {
	extern int QC[18];
	extern int isSelfClick[18];
	extern int isQC[18];
	void Init();
	void QC_HotkeysSetUp();
}
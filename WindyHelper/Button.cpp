#include "Button.h"
#include "Game.h"
namespace Button {
	typedef void(__fastcall* sub_6F13D870)(int a1);
	sub_6F13D870 sub_6F13D870_org;
	sub_6F13D870 sub_6F13D870_ptr;
	void __fastcall sub_6F13D870_my(int a1) { // Chỉ vào nó sẻ được tính
		return sub_6F13D870_ptr(a1);
	}
	void Init() {
		sub_6F13D870_org = (sub_6F13D870)(GameDll + 0x13D870);
		MH_CreateHook(sub_6F13D870_org, &sub_6F13D870_my, reinterpret_cast<void**>(&sub_6F13D870_ptr));
		MH_EnableHook(sub_6F13D870_org);
	}
}
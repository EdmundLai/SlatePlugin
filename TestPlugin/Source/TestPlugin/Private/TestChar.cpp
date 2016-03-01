
#include "TestPluginPrivatePCH.h"
#include "TestChar.h"
#include "TestLib.h" //引入的第三方库的头文件

ATestChar::ATestChar() : Super()
{
	mAge = myPrint("hello world", 123); //第三方库中的方法
	mName = "yangx";
}
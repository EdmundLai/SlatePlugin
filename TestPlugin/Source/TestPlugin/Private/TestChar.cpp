
#include "TestPluginPrivatePCH.h"
#include "TestChar.h"
#include "TestLib.h" //����ĵ��������ͷ�ļ�

ATestChar::ATestChar() : Super()
{
	mAge = myPrint("hello world", 123); //���������еķ���
	mName = "yangx";
}
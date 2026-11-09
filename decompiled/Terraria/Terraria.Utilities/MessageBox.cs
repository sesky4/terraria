using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using SDL3;

namespace Terraria.Utilities;

public static class MessageBox
{
	public static DialogResult Show(string message, string title, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
	{
		return buttons switch
		{
			MessageBoxButtons.OK => Show(message, title, new DialogResult[1] { DialogResult.OK }, icon, 0, 0), 
			MessageBoxButtons.OKCancel => Show(message, title, new DialogResult[2]
			{
				DialogResult.Cancel,
				DialogResult.OK
			}, icon, 0, 1), 
			MessageBoxButtons.YesNoCancel => Show(message, title, new DialogResult[3]
			{
				DialogResult.Yes,
				DialogResult.No,
				DialogResult.Cancel
			}, icon, 0, 2), 
			MessageBoxButtons.YesNo => Show(message, title, new DialogResult[2]
			{
				DialogResult.No,
				DialogResult.Yes
			}, icon, 0), 
			MessageBoxButtons.RetryCancel => Show(message, title, new DialogResult[2]
			{
				DialogResult.Cancel,
				DialogResult.Retry
			}, icon, 0, 1), 
			_ => throw new ArgumentOutOfRangeException("buttons"), 
		};
	}

	private static DialogResult Show(string message, string title, DialogResult[] buttons, MessageBoxIcon icon, int returnButtonIndex = -1, int cancelButtonIndex = -1)
	{
		string[] buttonLabels = buttons.Select((DialogResult r) => Enum.GetName(typeof(DialogResult), r)).ToArray();
		int num = Show(message, title, buttonLabels, -1, -1, icon);
		if (num >= 0)
		{
			return buttons[num];
		}
		return DialogResult.None;
	}

	private unsafe static byte* AllocUTF8(string s)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(s + "\0");
		byte* ptr = (byte*)(void*)Marshal.AllocHGlobal(bytes.Length);
		Marshal.Copy(bytes, 0, (IntPtr)ptr, bytes.Length);
		return ptr;
	}

	public unsafe static int Show(string message, string title, string[] buttonLabels, int returnButtonIndex = -1, int cancelButtonIndex = -1, MessageBoxIcon icon = MessageBoxIcon.None)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		SDL_MessageBoxButtonData* ptr = (SDL_MessageBoxButtonData*)(void*)Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SDL_MessageBoxButtonData)) * buttonLabels.Length);
		for (int i = 0; i < buttonLabels.Length; i++)
		{
			Unsafe.Write((byte*)ptr + (nint)i * (nint)Unsafe.SizeOf<SDL_MessageBoxButtonData>(), new SDL_MessageBoxButtonData
			{
				flags = (SDL_MessageBoxButtonFlags)((i == returnButtonIndex) ? 1 : ((i == cancelButtonIndex) ? 2 : 0)),
				buttonID = i,
				text = AllocUTF8(buttonLabels[i])
			});
		}
		SDL_MessageBoxData val = new SDL_MessageBoxData
		{
			flags = (SDL_MessageBoxFlags)(icon | (MessageBoxIcon)128u),
			message = AllocUTF8(message),
			title = AllocUTF8(title),
			buttons = ptr,
			numbuttons = buttonLabels.Length
		};
		try
		{
			int result = default(int);
			if (!SDLBool.op_Implicit(SDL.SDL_ShowMessageBox(ref val, ref result)))
			{
				return -1;
			}
			return result;
		}
		finally
		{
			for (int j = 0; j < buttonLabels.Length; j++)
			{
				Marshal.FreeHGlobal((IntPtr)((SDL_MessageBoxButtonData)((byte*)ptr + (nint)j * (nint)Unsafe.SizeOf<SDL_MessageBoxButtonData>())).text);
			}
			Marshal.FreeHGlobal((IntPtr)val.message);
			Marshal.FreeHGlobal((IntPtr)val.title);
		}
	}
}

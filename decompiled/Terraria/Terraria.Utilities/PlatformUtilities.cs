using System;
using System.IO;
using SDL3;

namespace Terraria.Utilities;

public static class PlatformUtilities
{
	public unsafe static void SavePng(string path, int width, int height, byte[] data)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		if (width * height * 4 > data.Length)
		{
			throw new IndexOutOfRangeException();
		}
		fixed (byte* ptr = data)
		{
			IntPtr intPtr = SDL.SDL_CreateSurfaceFrom(width, height, (SDL_PixelFormat)376840196, (IntPtr)ptr, width * 4);
			if (intPtr == IntPtr.Zero)
			{
				throw new IOException("Failed to create SDL surface: " + SDL.SDL_GetError());
			}
			try
			{
				IntPtr intPtr2 = SDL.SDL_IOFromFile(path, "wb");
				if (intPtr2 == IntPtr.Zero)
				{
					throw new IOException("Failed to open file for writing: " + SDL.SDL_GetError());
				}
				if (!SDLBool.op_Implicit(SDL.SDL_SavePNG_IO(intPtr, intPtr2, SDLBool.op_Implicit(true))))
				{
					throw new IOException("Failed to save PNG: " + SDL.SDL_GetError());
				}
			}
			finally
			{
				SDL.SDL_DestroySurface(intPtr);
			}
		}
	}
}

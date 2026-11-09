using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework
{
    public struct Vector2
    {
        public float X, Y;
        public Vector2(float x, float y) { X = x; Y = y; }
        public Vector2(float value) { X = Y = value; }
        public static Vector2 Zero => default;
        public static Vector2 One => new Vector2(1f, 1f);
        public static Vector2 UnitX => new Vector2(1f, 0f);
        public static Vector2 UnitY => new Vector2(0f, 1f);
        public const int Count = 2;
        public float Length() => 0f;
        public float LengthSquared() => 0f;
        public void Normalize() { }
        public static float Distance(Vector2 a, Vector2 b) => 0f;
        public static float DistanceSquared(Vector2 a, Vector2 b) => 0f;
        public static Vector2 Normalize(Vector2 v) => default;
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t) => default;
        public static Vector2 LerpPrecise(Vector2 a, Vector2 b, float t) => default;
        public static Vector2 SmoothStep(Vector2 a, Vector2 b, float t) => default;
        public static Vector2 Min(Vector2 a, Vector2 b) => default;
        public static Vector2 Max(Vector2 a, Vector2 b) => default;
        public static Vector2 Clamp(Vector2 v, Vector2 min, Vector2 max) => default;
        public static Vector2 Reflect(Vector2 v, Vector2 n) => default;
        public static Vector2 Transform(Vector2 v, Matrix m) => default;
        public static Vector2 TransformNormal(Vector2 v, Matrix m) => default;
        public static float Dot(Vector2 a, Vector2 b) => 0f;
        public static Vector2 CatmullRom(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t) => default;
        public static Vector2 Hermite(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t) => default;
        public static Vector2 Barycentric(Vector2 a, Vector2 b, Vector2 c, float u, float v) => default;
        public static Vector2 Abs(Vector2 v) => default;
        public static Vector2 SquareRoot(Vector2 v) => default;
        public static Vector2 Round(Vector2 v) => default;
        public static Vector2 Floor(Vector2 v) => default;
        public static Vector2 Ceiling(Vector2 v) => default;
        public static void Dot(ref Vector2 a, ref Vector2 b, out float r) { r = 0f; }
        public static void Distance(ref Vector2 a, ref Vector2 b, out float r) { r = 0f; }
        public static void DistanceSquared(ref Vector2 a, ref Vector2 b, out float r) { r = 0f; }
        public static void Normalize(ref Vector2 v, out Vector2 r) { r = default; }
        public static void Lerp(ref Vector2 a, ref Vector2 b, float t, out Vector2 r) { r = default; }
        public static void Add(ref Vector2 a, ref Vector2 b, out Vector2 r) { r = default; }
        public static void Subtract(ref Vector2 a, ref Vector2 b, out Vector2 r) { r = default; }
        public static void Multiply(ref Vector2 a, float s, out Vector2 r) { r = default; }
        public static void Multiply(ref Vector2 a, ref Vector2 b, out Vector2 r) { r = default; }
        public static void Divide(ref Vector2 a, float s, out Vector2 r) { r = default; }
        public static void Divide(ref Vector2 a, ref Vector2 b, out Vector2 r) { r = default; }
        public static void Transform(ref Vector2 v, ref Matrix m, out Vector2 r) { r = default; }
        public static void TransformNormal(ref Vector2 v, ref Matrix m, out Vector2 r) { r = default; }
        public static void CatmullRom(ref Vector2 a, ref Vector2 b, ref Vector2 c, ref Vector2 d, float t, out Vector2 r) { r = default; }
        public static void Hermite(ref Vector2 a, ref Vector2 b, ref Vector2 c, ref Vector2 d, float t, out Vector2 r) { r = default; }
        public static void SmoothStep(ref Vector2 a, ref Vector2 b, float t, out Vector2 r) { r = default; }
        public static void Min(ref Vector2 a, ref Vector2 b, out Vector2 r) { r = default; }
        public static void Max(ref Vector2 a, ref Vector2 b, out Vector2 r) { r = default; }
        public static void Clamp(ref Vector2 v, ref Vector2 min, ref Vector2 max, out Vector2 r) { r = default; }
        public static void Reflect(ref Vector2 v, ref Vector2 n, out Vector2 r) { r = default; }
        public static Vector2 operator +(Vector2 a, Vector2 b) => default;
        public static Vector2 operator -(Vector2 a, Vector2 b) => default;
        public static Vector2 operator *(Vector2 a, Vector2 b) => default;
        public static Vector2 operator *(Vector2 a, float s) => default;
        public static Vector2 operator *(float s, Vector2 a) => default;
        public static Vector2 operator /(Vector2 a, Vector2 b) => default;
        public static Vector2 operator /(Vector2 a, float s) => default;
        public static Vector2 operator -(Vector2 a) => default;
        public static bool operator ==(Vector2 a, Vector2 b) => false;
        public static bool operator !=(Vector2 a, Vector2 b) => false;
        public override bool Equals(object obj) => false;
        public bool Equals(Vector2 other) => false;
        public override int GetHashCode() => 0;
        public override string ToString() => "";
    }

    public struct Vector3
    {
        public float X, Y, Z;
        public Vector3(float x, float y, float z) { X = x; Y = y; Z = z; }
        public Vector3(float value) { X = Y = Z = value; }
        public static Vector3 Zero => default;
        public static Vector3 One => new Vector3(1f, 1f, 1f);
        public static Vector3 UnitX => new Vector3(1f, 0f, 0f);
        public static Vector3 UnitY => new Vector3(0f, 1f, 0f);
        public static Vector3 UnitZ => new Vector3(0f, 0f, 1f);
        public static Vector3 Up => new Vector3(0f, 1f, 0f);
        public static Vector3 Down => new Vector3(0f, -1f, 0f);
        public static Vector3 Left => new Vector3(-1f, 0f, 0f);
        public static Vector3 Right => new Vector3(1f, 0f, 0f);
        public static Vector3 Forward => new Vector3(0f, 0f, -1f);
        public static Vector3 Backward => new Vector3(0f, 0f, 1f);
        public float Length() => 0f;
        public float LengthSquared() => 0f;
        public void Normalize() { }
        public static Vector3 Normalize(Vector3 v) => default;
        public static float Distance(Vector3 a, Vector3 b) => 0f;
        public static Vector3 Cross(Vector3 a, Vector3 b) => default;
        public static float Dot(Vector3 a, Vector3 b) => 0f;
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t) => default;
        public static Vector3 SmoothStep(Vector3 a, Vector3 b, float t) => default;
        public static Vector3 Min(Vector3 a, Vector3 b) => default;
        public static Vector3 Max(Vector3 a, Vector3 b) => default;
        public static Vector3 Clamp(Vector3 v, Vector3 min, Vector3 max) => default;
        public static Vector3 Transform(Vector3 v, Matrix m) => default;
        public static Vector3 TransformNormal(Vector3 v, Matrix m) => default;
        public static void Transform(ref Vector3 v, ref Matrix m, out Vector3 r) { r = default; }
        public static void TransformNormal(ref Vector3 v, ref Matrix m, out Vector3 r) { r = default; }
        public static void Add(ref Vector3 a, ref Vector3 b, out Vector3 r) { r = default; }
        public static void Subtract(ref Vector3 a, ref Vector3 b, out Vector3 r) { r = default; }
        public static void Multiply(ref Vector3 a, float s, out Vector3 r) { r = default; }
        public static void Divide(ref Vector3 a, float s, out Vector3 r) { r = default; }
        public static void Cross(ref Vector3 a, ref Vector3 b, out Vector3 r) { r = default; }
        public static void Dot(ref Vector3 a, ref Vector3 b, out float r) { r = 0f; }
        public static void Normalize(ref Vector3 v, out Vector3 r) { r = default; }
        public static void Lerp(ref Vector3 a, ref Vector3 b, float t, out Vector3 r) { r = default; }
        public static void Distance(ref Vector3 a, ref Vector3 b, out float r) { r = 0f; }
        public static void Min(ref Vector3 a, ref Vector3 b, out Vector3 r) { r = default; }
        public static void Max(ref Vector3 a, ref Vector3 b, out Vector3 r) { r = default; }
        public static void Clamp(ref Vector3 v, ref Vector3 min, ref Vector3 max, out Vector3 r) { r = default; }
        public static Vector3 operator +(Vector3 a, Vector3 b) => default;
        public static Vector3 operator -(Vector3 a, Vector3 b) => default;
        public static Vector3 operator *(Vector3 a, Vector3 b) => default;
        public static Vector3 operator *(Vector3 a, float s) => default;
        public static Vector3 operator *(float s, Vector3 a) => default;
        public static Vector3 operator /(Vector3 a, float s) => default;
        public static Vector3 operator -(Vector3 a) => default;
        public static bool operator ==(Vector3 a, Vector3 b) => false;
        public static bool operator !=(Vector3 a, Vector3 b) => false;
        public override bool Equals(object obj) => false;
        public bool Equals(Vector3 other) => false;
        public override int GetHashCode() => 0;
        public override string ToString() => "";
    }

    public struct Vector4
    {
        public float X, Y, Z, W;
        public Vector4(float x, float y, float z, float w) { X = x; Y = y; Z = z; W = w; }
        public Vector4(float value) { X = Y = Z = W = value; }
        public static Vector4 Zero => default;
        public static Vector4 One => new Vector4(1f, 1f, 1f, 1f);
        public static Vector4 UnitX => new Vector4(1f, 0f, 0f, 0f);
        public static Vector4 UnitY => new Vector4(0f, 1f, 0f, 0f);
        public static Vector4 UnitZ => new Vector4(0f, 0f, 1f, 0f);
        public static Vector4 UnitW => new Vector4(0f, 0f, 0f, 1f);
        public float Length() => 0f;
        public float LengthSquared() => 0f;
        public void Normalize() { }
        public static Vector4 Normalize(Vector4 v) => default;
        public static float Distance(Vector4 a, Vector4 b) => 0f;
        public static float Dot(Vector4 a, Vector4 b) => 0f;
        public static Vector4 Lerp(Vector4 a, Vector4 b, float t) => default;
        public static Vector4 SmoothStep(Vector4 a, Vector4 b, float t) => default;
        public static Vector4 Min(Vector4 a, Vector4 b) => default;
        public static Vector4 Max(Vector4 a, Vector4 b) => default;
        public static Vector4 Clamp(Vector4 v, Vector4 min, Vector4 max) => default;
        public static Vector4 Transform(Vector4 v, Matrix m) => default;
        public static void Transform(ref Vector4 v, ref Matrix m, out Vector4 r) { r = default; }
        public static void Add(ref Vector4 a, ref Vector4 b, out Vector4 r) { r = default; }
        public static void Subtract(ref Vector4 a, ref Vector4 b, out Vector4 r) { r = default; }
        public static void Multiply(ref Vector4 a, float s, out Vector4 r) { r = default; }
        public static void Divide(ref Vector4 a, float s, out Vector4 r) { r = default; }
        public static void Normalize(ref Vector4 v, out Vector4 r) { r = default; }
        public static void Lerp(ref Vector4 a, ref Vector4 b, float t, out Vector4 r) { r = default; }
        public static void Min(ref Vector4 a, ref Vector4 b, out Vector4 r) { r = default; }
        public static void Max(ref Vector4 a, ref Vector4 b, out Vector4 r) { r = default; }
        public static void Clamp(ref Vector4 v, ref Vector4 min, ref Vector4 max, out Vector4 r) { r = default; }
        public static void Distance(ref Vector4 a, ref Vector4 b, out float r) { r = 0f; }
        public static void Dot(ref Vector4 a, ref Vector4 b, out float r) { r = 0f; }
        public static Vector4 operator +(Vector4 a, Vector4 b) => default;
        public static Vector4 operator -(Vector4 a, Vector4 b) => default;
        public static Vector4 operator *(Vector4 a, float s) => default;
        public static Vector4 operator *(float s, Vector4 a) => default;
        public static Vector4 operator /(Vector4 a, float s) => default;
        public static Vector4 operator -(Vector4 a) => default;
        public static bool operator ==(Vector4 a, Vector4 b) => false;
        public static bool operator !=(Vector4 a, Vector4 b) => false;
        public override bool Equals(object obj) => false;
        public bool Equals(Vector4 other) => false;
        public override int GetHashCode() => 0;
        public override string ToString() => "";
    }

    public struct Matrix
    {
        public float M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44;
        public Matrix(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24,
                      float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
        { M11 = m11; M12 = m12; M13 = m13; M14 = m14; M21 = m21; M22 = m22; M23 = m23; M24 = m24;
          M31 = m31; M32 = m32; M33 = m33; M34 = m34; M41 = m41; M42 = m42; M43 = m43; M44 = m44; }
        public static Matrix Identity => default;
        public static Matrix CreateTranslation(float x, float y, float z) => default;
        public static Matrix CreateTranslation(Vector3 p) => default;
        public static Matrix CreateScale(float s) => default;
        public static Matrix CreateScale(float x, float y, float z) => default;
        public static Matrix CreateRotationZ(float r) => default;
        public static Matrix CreateRotationX(float r) => default;
        public static Matrix CreateRotationY(float r) => default;
        public static Matrix CreateOrthographicOffCenter(float l, float r, float b, float t, float zn, float zf) => default;
        public static Matrix CreateLookAt(Vector3 cam, Vector3 target, Vector3 up) => default;
        public static Matrix CreatePerspectiveFieldOfView(float fov, float aspect, float zn, float zf) => default;
        public static Matrix Invert(Matrix m) => default;
        public static void Invert(ref Matrix m, out Matrix r) { r = default; }
        public static Matrix Transpose(Matrix m) => default;
        public static void Transpose(ref Matrix m, out Matrix r) { r = default; }
        public static Matrix Lerp(Matrix a, Matrix b, float t) => default;
        public static Matrix Add(Matrix a, Matrix b) => default;
        public static Matrix Multiply(Matrix a, Matrix b) => default;
        public static Matrix Multiply(Matrix a, float s) => default;
        public static Matrix operator *(Matrix a, Matrix b) => default;
        public static Matrix operator *(Matrix a, float s) => default;
        public static Matrix operator +(Matrix a, Matrix b) => default;
        public static Matrix operator -(Matrix a, Matrix b) => default;
        public static bool operator ==(Matrix a, Matrix b) => false;
        public static bool operator !=(Matrix a, Matrix b) => false;
        public override bool Equals(object obj) => false;
        public bool Equals(Matrix other) => false;
        public override int GetHashCode() => 0;
        public override string ToString() => "";
    }

    public struct Quaternion
    {
        public float X, Y, Z, W;
        public Quaternion(float x, float y, float z, float w) { X = x; Y = y; Z = z; W = w; }
        public static Quaternion Identity => new Quaternion(0f, 0f, 0f, 1f);
        public static Quaternion CreateFromAxisAngle(Vector3 axis, float angle) => default;
        public static Quaternion CreateFromYawPitchRoll(float yaw, float pitch, float roll) => default;
        public static Quaternion Slerp(Quaternion a, Quaternion b, float t) => default;
        public static Quaternion Lerp(Quaternion a, Quaternion b, float t) => default;
        public static Quaternion Normalize(Quaternion q) => default;
        public static void Normalize(ref Quaternion q, out Quaternion r) { r = default; }
        public static float Dot(Quaternion a, Quaternion b) => 0f;
        public static Quaternion Inverse(Quaternion q) => default;
        public static Quaternion Conjugate(Quaternion q) => default;
        public static Quaternion Multiply(Quaternion a, Quaternion b) => default;
        public static Quaternion operator *(Quaternion a, Quaternion b) => default;
        public static Quaternion operator *(Quaternion a, float s) => default;
        public static Quaternion operator +(Quaternion a, Quaternion b) => default;
        public static Quaternion operator -(Quaternion a, Quaternion b) => default;
        public static bool operator ==(Quaternion a, Quaternion b) => false;
        public static bool operator !=(Quaternion a, Quaternion b) => false;
        public override bool Equals(object obj) => false;
        public bool Equals(Quaternion other) => false;
        public override int GetHashCode() => 0;
    }

    public struct Point
    {
        public int X, Y;
        public Point(int x, int y) { X = x; Y = y; }
        public static Point Zero => default;
        public static Point operator +(Point a, Point b) => default;
        public static Point operator -(Point a, Point b) => default;
        public static Point operator *(Point a, int s) => default;
        public static Point operator *(int s, Point a) => default;
        public static Point operator /(Point a, int s) => default;
        public static bool operator ==(Point a, Point b) => false;
        public static bool operator !=(Point a, Point b) => false;
        public override bool Equals(object obj) => false;
        public bool Equals(Point other) => false;
        public override int GetHashCode() => 0;
        public override string ToString() => "";
    }

    public struct Rectangle
    {
        public int X, Y, Width, Height;
        public Rectangle(int x, int y, int w, int h) { X = x; Y = y; Width = w; Height = h; }
        public int Left => 0;
        public int Right => 0;
        public int Top => 0;
        public int Bottom => 0;
        public Point Location => default;
        public Point Center => default;
        public static Rectangle Empty => default;
        public bool IsEmpty => false;
        public void Offset(int x, int y) { }
        public void Offset(Point p) { }
        public void Inflate(int x, int y) { }
        public void Inflate(float x, float y) { }
        public static Rectangle Inflate(Rectangle rect, int x, int y) => default;
        public bool Contains(int x, int y) => false;
        public bool Contains(Point p) => false;
        public bool Contains(Vector2 v) => false;
        public bool Contains(Rectangle r) => false;
        public static Rectangle Union(Rectangle a, Rectangle b) => default;
        public void Intersect(Rectangle r) { }
        public static Rectangle Intersect(Rectangle a, Rectangle b) => default;
        public bool Intersects(Rectangle r) => false;
        public static Point[] GetScreenSpaceRectangle(Rectangle a, Rectangle b) => null;
        public static Rectangle FromLTRB(int l, int t, int r, int b) => default;
        public static bool operator ==(Rectangle a, Rectangle b) => false;
        public static bool operator !=(Rectangle a, Rectangle b) => false;
        public override bool Equals(object obj) => false;
        public bool Equals(Rectangle other) => false;
        public override int GetHashCode() => 0;
        public override string ToString() => "";
    }

    public struct Color : IEquatable<Color>
    {
        public byte R, G, B, A;
        public Color(byte r, byte g, byte b) { R = r; G = g; B = b; A = 255; }
        public Color(byte r, byte g, byte b, byte a) { R = r; G = g; B = b; A = a; }
        public Color(int r, int g, int b) { R = (byte)r; G = (byte)g; B = (byte)b; A = 255; }
        public Color(int r, int g, int b, int a) { R = (byte)r; G = (byte)g; B = (byte)b; A = (byte)a; }
        public Color(float r, float g, float b) { R = (byte)(r * 255f); G = (byte)(g * 255f); B = (byte)(b * 255f); A = 255; }
        public Color(float r, float g, float b, float a) { R = (byte)(r * 255f); G = (byte)(g * 255f); B = (byte)(b * 255f); A = (byte)(a * 255f); }
        public Color(Vector3 v) { R = (byte)(v.X * 255f); G = (byte)(v.Y * 255f); B = (byte)(v.Z * 255f); A = 255; }
        public Color(Vector4 v) { R = (byte)(v.X * 255f); G = (byte)(v.Y * 255f); B = (byte)(v.Z * 255f); A = (byte)(v.W * 255f); }
        public Color(uint packed) { R = (byte)(packed & 0xFF); G = (byte)((packed >> 8) & 0xFF); B = (byte)((packed >> 16) & 0xFF); A = (byte)((packed >> 24) & 0xFF); }
        public static Color Transparent => new Color(255, 255, 255, 0);
        public static Color AliceBlue => new Color(240, 248, 255);
        public static Color AntiqueWhite => new Color(250, 235, 215);
        public static Color Aqua => new Color(0, 255, 255);
        public static Color Aquamarine => new Color(127, 255, 212);
        public static Color Azure => new Color(240, 255, 255);
        public static Color Beige => new Color(245, 245, 220);
        public static Color Bisque => new Color(255, 228, 196);
        public static Color Black => new Color(0, 0, 0);
        public static Color BlanchedAlmond => new Color(255, 235, 205);
        public static Color Blue => new Color(0, 0, 255);
        public static Color BlueViolet => new Color(138, 43, 226);
        public static Color Brown => new Color(165, 42, 42);
        public static Color BurlyWood => new Color(222, 184, 135);
        public static Color CadetBlue => new Color(95, 158, 160);
        public static Color Chartreuse => new Color(127, 255, 0);
        public static Color Chocolate => new Color(210, 105, 30);
        public static Color Coral => new Color(255, 127, 80);
        public static Color CornflowerBlue => new Color(100, 149, 237);
        public static Color Cornsilk => new Color(255, 248, 220);
        public static Color Crimson => new Color(220, 20, 60);
        public static Color Cyan => new Color(0, 255, 255);
        public static Color DarkBlue => new Color(0, 0, 139);
        public static Color DarkCyan => new Color(0, 139, 139);
        public static Color DarkGoldenrod => new Color(184, 134, 11);
        public static Color DarkGray => new Color(169, 169, 169);
        public static Color DarkGreen => new Color(0, 100, 0);
        public static Color DarkKhaki => new Color(189, 183, 107);
        public static Color DarkMagenta => new Color(139, 0, 139);
        public static Color DarkOliveGreen => new Color(85, 107, 47);
        public static Color DarkOrange => new Color(255, 140, 0);
        public static Color DarkOrchid => new Color(153, 50, 204);
        public static Color DarkRed => new Color(139, 0, 0);
        public static Color DarkSalmon => new Color(233, 150, 122);
        public static Color DarkSeaGreen => new Color(143, 188, 143);
        public static Color DarkSlateBlue => new Color(72, 61, 139);
        public static Color DarkSlateGray => new Color(47, 79, 79);
        public static Color DarkTurquoise => new Color(0, 206, 209);
        public static Color DarkViolet => new Color(148, 0, 211);
        public static Color DeepPink => new Color(255, 20, 147);
        public static Color DeepSkyBlue => new Color(0, 191, 255);
        public static Color DimGray => new Color(105, 105, 105);
        public static Color DodgerBlue => new Color(30, 144, 255);
        public static Color Firebrick => new Color(178, 34, 34);
        public static Color FloralWhite => new Color(255, 250, 240);
        public static Color ForestGreen => new Color(34, 139, 34);
        public static Color Fuchsia => new Color(255, 0, 255);
        public static Color Gainsboro => new Color(220, 220, 220);
        public static Color GhostWhite => new Color(248, 248, 255);
        public static Color Gold => new Color(255, 215, 0);
        public static Color Goldenrod => new Color(218, 165, 32);
        public static Color Gray => new Color(128, 128, 128);
        public static Color Green => new Color(0, 128, 0);
        public static Color GreenYellow => new Color(173, 255, 47);
        public static Color Honeydew => new Color(240, 255, 240);
        public static Color HotPink => new Color(255, 105, 180);
        public static Color IndianRed => new Color(205, 92, 92);
        public static Color Indigo => new Color(75, 0, 130);
        public static Color Ivory => new Color(255, 255, 240);
        public static Color Khaki => new Color(240, 230, 140);
        public static Color Lavender => new Color(230, 230, 250);
        public static Color LavenderBlush => new Color(255, 240, 245);
        public static Color LawnGreen => new Color(124, 252, 0);
        public static Color LemonChiffon => new Color(255, 250, 205);
        public static Color LightBlue => new Color(173, 216, 230);
        public static Color LightCoral => new Color(240, 128, 128);
        public static Color LightCyan => new Color(224, 255, 255);
        public static Color LightGoldenrodYellow => new Color(250, 250, 210);
        public static Color LightGray => new Color(211, 211, 211);
        public static Color LightGreen => new Color(144, 238, 144);
        public static Color LightPink => new Color(255, 182, 193);
        public static Color LightSalmon => new Color(255, 160, 122);
        public static Color LightSeaGreen => new Color(32, 178, 170);
        public static Color LightSkyBlue => new Color(135, 206, 250);
        public static Color LightSlateGray => new Color(119, 136, 153);
        public static Color LightSteelBlue => new Color(176, 196, 222);
        public static Color LightYellow => new Color(255, 255, 224);
        public static Color Lime => new Color(0, 255, 0);
        public static Color LimeGreen => new Color(50, 205, 50);
        public static Color Linen => new Color(250, 240, 230);
        public static Color Magenta => new Color(255, 0, 255);
        public static Color Maroon => new Color(128, 0, 0);
        public static Color MediumAquamarine => new Color(102, 205, 170);
        public static Color MediumBlue => new Color(0, 0, 205);
        public static Color MediumOrchid => new Color(186, 85, 211);
        public static Color MediumPurple => new Color(147, 112, 219);
        public static Color MediumSeaGreen => new Color(60, 179, 113);
        public static Color MediumSlateBlue => new Color(123, 104, 238);
        public static Color MediumSpringGreen => new Color(0, 250, 154);
        public static Color MediumTurquoise => new Color(72, 209, 204);
        public static Color MediumVioletRed => new Color(199, 21, 133);
        public static Color MidnightBlue => new Color(25, 25, 112);
        public static Color MintCream => new Color(245, 255, 250);
        public static Color MistyRose => new Color(255, 228, 225);
        public static Color Moccasin => new Color(255, 228, 181);
        public static Color NavajoWhite => new Color(255, 222, 173);
        public static Color Navy => new Color(0, 0, 128);
        public static Color OldLace => new Color(253, 245, 230);
        public static Color Olive => new Color(128, 128, 0);
        public static Color OliveDrab => new Color(107, 142, 35);
        public static Color Orange => new Color(255, 165, 0);
        public static Color OrangeRed => new Color(255, 69, 0);
        public static Color Orchid => new Color(218, 112, 214);
        public static Color PaleGoldenrod => new Color(238, 232, 170);
        public static Color PaleGreen => new Color(152, 251, 152);
        public static Color PaleTurquoise => new Color(175, 238, 238);
        public static Color PaleVioletRed => new Color(219, 112, 147);
        public static Color PapayaWhip => new Color(255, 239, 213);
        public static Color PeachPuff => new Color(255, 218, 185);
        public static Color Peru => new Color(205, 133, 63);
        public static Color Pink => new Color(255, 192, 203);
        public static Color Plum => new Color(221, 160, 221);
        public static Color PowderBlue => new Color(176, 224, 230);
        public static Color Purple => new Color(128, 0, 128);
        public static Color Red => new Color(255, 0, 0);
        public static Color RosyBrown => new Color(188, 143, 143);
        public static Color RoyalBlue => new Color(65, 105, 225);
        public static Color SaddleBrown => new Color(139, 69, 19);
        public static Color Salmon => new Color(250, 128, 114);
        public static Color SandyBrown => new Color(244, 164, 96);
        public static Color SeaGreen => new Color(46, 139, 87);
        public static Color SeaShell => new Color(255, 245, 238);
        public static Color Sienna => new Color(160, 82, 45);
        public static Color Silver => new Color(192, 192, 192);
        public static Color SkyBlue => new Color(135, 206, 235);
        public static Color SlateBlue => new Color(106, 90, 205);
        public static Color SlateGray => new Color(112, 128, 144);
        public static Color Snow => new Color(255, 250, 250);
        public static Color SpringGreen => new Color(0, 255, 127);
        public static Color SteelBlue => new Color(70, 130, 180);
        public static Color Tan => new Color(210, 180, 140);
        public static Color Teal => new Color(0, 128, 128);
        public static Color Thistle => new Color(216, 191, 216);
        public static Color Tomato => new Color(255, 99, 71);
        public static Color Turquoise => new Color(64, 224, 208);
        public static Color Violet => new Color(238, 130, 238);
        public static Color Wheat => new Color(245, 222, 179);
        public static Color White => new Color(255, 255, 255);
        public static Color WhiteSmoke => new Color(245, 245, 245);
        public static Color Yellow => new Color(255, 255, 0);
        public static Color YellowGreen => new Color(154, 205, 50);
        public static Color Black_Transparent => new Color(0, 0, 0, 0);
        public Vector3 ToVector3() => default;
        public Vector4 ToVector4() => default;
        public uint PackedValue => 0u;
        public static Color FromNonPremultiplied(Vector4 v) => default;
        public static Color FromNonPremultiplied(int r, int g, int b, int a) => default;
        public static Color Lerp(Color a, Color b, float t) => default;
        public static void Lerp(ref Color a, ref Color b, float t, out Color r) { r = default; }
        public static Color Multiply(Color a, float s) => default;
        public static Color operator *(Color a, float s) => default;
        public static Color operator *(float s, Color a) => default;
        public static Color operator *(Color a, Color b) => default;
        public static Color operator +(Color a, Color b) => default;
        public static Color operator -(Color a, Color b) => default;
        public static Color operator /(Color a, float s) => default;
        public static bool operator ==(Color a, Color b) => false;
        public static bool operator !=(Color a, Color b) => false;
        public override bool Equals(object obj) => false;
        public bool Equals(Color other) => false;
        public override int GetHashCode() => 0;
        public override string ToString() => "";
        public static implicit operator Color(uint packedValue) => default;
        public static explicit operator uint(Color color) => 0u;
    }

    public struct BoundingBox
    {
        public Vector3 Min, Max;
        public BoundingBox(Vector3 min, Vector3 max) { Min = min; Max = max; }
        public static BoundingBox CreateFromPoints(IEnumerable<Vector3> points) => default;
        public bool Contains(Vector3 p) => false;
        public bool Intersects(BoundingBox b) => false;
        public bool Contains(BoundingBox b, out bool result) { result = false; return false; }
        public bool Intersects(BoundingBox b, out bool result) { result = false; return false; }
        public BoundingBox Transform(Matrix m) => default;
        public bool Equals(BoundingBox other) => false;
        public override bool Equals(object obj) => false;
        public override int GetHashCode() => 0;
    }

    public struct BoundingSphere
    {
        public Vector3 Center;
        public float Radius;
        public BoundingSphere(Vector3 center, float radius) { Center = center; Radius = radius; }
        public bool Contains(Vector3 p) => false;
        public bool Intersects(BoundingSphere s) => false;
        public bool Contains(BoundingSphere s, out bool result) { result = false; return false; }
    }

    public struct Ray
    {
        public Vector3 Position, Direction;
        public Ray(Vector3 position, Vector3 direction) { Position = position; Direction = direction; }
        public float? Intersects(BoundingBox box) => null;
        public float? Intersects(BoundingSphere sphere) => null;
        public float? Intersects(Plane plane) => null;
    }

    public struct Plane
    {
        public Vector3 Normal;
        public float D;
        public Plane(Vector3 normal, float d) { Normal = normal; D = d; }
        public Plane(float a, float b, float c, float d) { Normal = default; D = d; }
        public float Dot(Vector3 v) => 0f;
        public float Dot(Vector4 v) => 0f;
        public static Plane Normalize(Plane p) => default;
        public void Normalize() { }
        public bool Equals(Plane other) => false;
        public override bool Equals(object obj) => false;
        public override int GetHashCode() => 0;
    }

    public class GameTime
    {
        public TimeSpan TotalGameTime { get; set; }
        public TimeSpan ElapsedGameTime { get; set; }
    }

    public struct GameTimeSpan
    {
        private long _ticks;
        public TimeSpan Ticks => default;
    }

    public enum CurveLoopType { Constant, Cycle, CycleOffset, Oscillate, Linear }
    public enum CurveContinuity { Smooth, Step }
    public class CurveKey
    {
        public float Position, Value;
        public float TangentIn, TangentOut;
        public CurveContinuity Continuity;
    }
    public class CurveKeyCollection : ICollection<CurveKey>
    {
        public int Count => 0;
        public bool IsReadOnly => true;
        public CurveKey this[int index] => null;
        public void Add(CurveKey item) { }
        public void Clear() { }
        public bool Contains(CurveKey item) => false;
        public void CopyTo(CurveKey[] array, int arrayIndex) { }
        public IEnumerator<CurveKey> GetEnumerator() => null;
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => null;
        public int IndexOf(CurveKey item) => 0;
        public void RemoveAt(int index) { }
        public bool Remove(CurveKey item) => false;
    }
    public class Curve
    {
        public CurveKeyCollection Keys { get; }
        public bool IsConstant { get; set; }
        public float PreLoopValue { get; set; }
        public float PostLoopValue { get; set; }
        public CurveLoopType PreLoop { get; set; }
        public CurveLoopType PostLoop { get; set; }
        public float Evaluate(float position) => 0f;
        public void ComputeTangent(int keyIndex, CurveTangent tangentType) { }
    }
    public enum CurveTangent { Flat, Linear, Smooth }
}

namespace Microsoft.Xna.Framework.Graphics
{
    // net40 缺少 IReadOnlyList<T>，这里补一个等价定义（仅编译桩使用）
    public interface IReadOnlyList<out T> : IEnumerable<T>
    {
        int Count { get; }
        T this[int index] { get; }
    }

    public class Texture
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public SurfaceFormat Format { get; protected set; }
        public string Name { get; set; }
        public void Dispose() { }
        public void GetData<T>(T[] data) { }
        public void GetData<T>(T[] data, int startIndex, int elementCount) { }
        public void SetData<T>(T[] data) { }
        public void SetData<T>(T[] data, int startIndex, int elementCount) { }
    }

    public class Texture2D : Texture
    {
        public Texture2D() { }
        public Texture2D(GraphicsDevice device, int width, int height) { Width = width; Height = height; }
        public Texture2D(GraphicsDevice device, int width, int height, bool mipmap, SurfaceFormat format) { Width = width; Height = height; }
        public void SaveAsPng(System.IO.Stream stream, int width, int height) { }
        public void SaveAsJpeg(System.IO.Stream stream, int width, int height) { }
        public void SetData<T>(T[] data, int startIndex, int elementCount, int width, int height) { }
        public void GetData<T>(T[] data, int startIndex, int elementCount, int width, int height) { }
    }

    public class Texture3D : Texture { }
    public class TextureCube : Texture { }

    public class RenderTarget2D : Texture2D
    {
        public int LevelCount { get; }
        public RenderTargetUsage RenderTargetUsage { get; }
        public DepthFormat DepthStencilFormat { get; }
        public Texture2D Texture => null;
        internal RenderTarget2D() { }
        public RenderTarget2D(GraphicsDevice device, int w, int h) { }
        public RenderTarget2D(GraphicsDevice device, int w, int h, bool mipmap, SurfaceFormat f, DepthFormat d) { }
    }

    public class RenderTargetCube : TextureCube { }

    public class RenderTargetBinding
    {
        public RenderTarget2D RenderTarget { get; }
        public RenderTargetBinding(RenderTarget2D target) { RenderTarget = target; }
    }

    public class VertexBuffer : IDisposable
    {
        public VertexBuffer(GraphicsDevice device, VertexDeclaration declaration, int vertexCount, BufferUsage usage) { }
        public VertexBuffer(GraphicsDevice device, VertexDeclaration declaration, int vertexCount, BufferUsage usage, bool dynamic) { }
        public VertexBuffer(GraphicsDevice device, Type vertexType, int vertexCount, BufferUsage usage) { }
        public void SetData<T>(T[] data) { }
        public void SetData<T>(T[] data, int startIndex, int elementCount) { }
        public void SetData<T>(T[] data, int startIndex, int elementCount, SetDataOptions options) { }
        public void Dispose() { }
    }

    public class IndexBuffer : IDisposable
    {
        public IndexBuffer(GraphicsDevice device, IndexElementSize size, int indexCount, BufferUsage usage) { }
        public IndexBuffer(GraphicsDevice device, Type indexType, int indexCount, BufferUsage usage) { }
        public void SetData<T>(T[] data) { }
        public void SetData<T>(T[] data, int startIndex, int elementCount) { }
        public void Dispose() { }
    }

    public class VertexDeclaration : IDisposable
    {
        public VertexDeclaration(int vertexStride, params VertexElement[] elements) { }
        public VertexDeclaration(params VertexElement[] elements) { }
        public int VertexStride { get; }
        public VertexElement[] GetVertexElements() => null;
        public void Dispose() { }
    }

    public struct VertexElement
    {
        public VertexElement(int offset, VertexElementFormat elementFormat, VertexElementUsage elementUsage, int usageIndex) { Stream = 0; Offset = offset; VertexElementFormat = elementFormat; VertexElementUsage = elementUsage; UsageIndex = usageIndex; }
        public VertexElement(int stream, int offset, VertexElementFormat elementFormat, VertexElementUsage elementUsage, int usageIndex) { Stream = stream; Offset = offset; VertexElementFormat = elementFormat; VertexElementUsage = elementUsage; UsageIndex = usageIndex; }
        public int Offset;
        public int Stream;
        public VertexElementFormat VertexElementFormat;
        public VertexElementUsage VertexElementUsage;
        public int UsageIndex;
        public static bool operator ==(VertexElement a, VertexElement b) => false;
        public static bool operator !=(VertexElement a, VertexElement b) => false;
        public override bool Equals(object obj) => false;
        public override int GetHashCode() => 0;
    }

    public interface IVertexType
    {
        VertexDeclaration VertexDeclaration { get; }
    }

    public interface IEffectMatrices
    {
        Matrix World { get; set; }
        Matrix View { get; set; }
        Matrix Projection { get; set; }
    }

    public interface IEffectLights { }
    public interface IEffectFog { }

    public class Effect : IDisposable
    {
        public Effect(GraphicsDevice device, byte[] effectCode) { }
        public Effect(GraphicsDevice device, byte[] effectCode, int index, int count) { }
        public EffectTechnique CurrentTechnique { get; set; }
        public EffectTechniqueCollection Techniques { get; }
        public EffectParameterCollection Parameters { get; }
        public EffectPassCollection CurrentTechniquePasses => null;
        public bool IsDisposed => false;
        public void Dispose() { }
    }

    public class EffectTechnique
    {
        public string Name { get; }
        public EffectPassCollection Passes { get; }
    }

    public class EffectTechniqueCollection : IReadOnlyList<EffectTechnique>
    {
        public int Count => 0;
        public EffectTechnique this[int index] => null;
        public EffectTechnique this[string name] => null;
        public IEnumerator<EffectTechnique> GetEnumerator() => null;
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => null;
    }

    public class EffectPass
    {
        public string Name { get; }
        public void Apply() { }
        public void Apply(int pass) { }
    }

    public class EffectPassCollection : IReadOnlyList<EffectPass>
    {
        public int Count => 0;
        public EffectPass this[int index] => null;
        public EffectPass this[string name] => null;
        public IEnumerator<EffectPass> GetEnumerator() => null;
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => null;
    }

    public class EffectParameter
    {
        public string Name { get; }
        public EffectParameterCollection Elements { get; }
        public EffectParameterCollection StructureMembers { get; }
        public void SetValue(bool value) { }
        public void SetValue(bool[] value) { }
        public void SetValue(int value) { }
        public void SetValue(int[] value) { }
        public void SetValue(float value) { }
        public void SetValue(float[] value) { }
        public void SetValue(float value1, float value2) { }
        public void SetValue(float value1, float value2, float value3) { }
        public void SetValue(float value1, float value2, float value3, float value4) { }
        public void SetValue(Vector2 value) { }
        public void SetValue(Vector2[] value) { }
        public void SetValue(Vector3 value) { }
        public void SetValue(Vector3[] value) { }
        public void SetValue(Vector4 value) { }
        public void SetValue(Vector4[] value) { }
        public void SetValue(Matrix value) { }
        public void SetValue(Matrix[] value) { }
        public void SetValue(Quaternion value) { }
        public void SetValue(Texture value) { }
        public void SetValue(Texture2D value) { }
        public bool GetValueBoolean() => false;
        public bool[] GetValueBooleanArray(int count) => null;
        public int GetValueInt32() => 0;
        public int[] GetValueInt32Array(int count) => null;
        public float GetValueSingle() => 0f;
        public float[] GetValueSingleArray(int count) => null;
        public Vector2 GetValueVector2() => default;
        public Vector3 GetValueVector3() => default;
        public Vector4 GetValueVector4() => default;
        public Matrix GetValueMatrix() => default;
        public Quaternion GetValueQuaternion() => default;
        public Texture GetValueTexture2D() => null;
    }

    public class EffectParameterCollection : IReadOnlyList<EffectParameter>
    {
        public int Count => 0;
        public EffectParameter this[int index] => null;
        public EffectParameter this[string name] => null;
        public IEnumerator<EffectParameter> GetEnumerator() => null;
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => null;
    }

    public class BasicEffect : Effect, IEffectMatrices
    {
        public BasicEffect(GraphicsDevice device) : base(device, null) { }
        public Matrix World { get; set; }
        public Matrix View { get; set; }
        public Matrix Projection { get; set; }
        public Vector3 DiffuseColor { get; set; }
        public Vector3 EmissiveColor { get; set; }
        public Vector3 SpecularColor { get; set; }
        public float SpecularPower { get; set; }
        public float Alpha { get; set; }
        public bool TextureEnabled { get; set; }
        public bool VertexColorEnabled { get; set; }
        public bool LightingEnabled { get; set; }
        public bool PreferPerPixelLighting { get; set; }
        public Texture2D Texture { get; set; }
        public void EnableDefaultLighting() { }
    }

    public class AlphaTestEffect : Effect, IEffectMatrices
    {
        public AlphaTestEffect(GraphicsDevice device) : base(device, null) { }
        public Matrix World { get; set; }
        public Matrix View { get; set; }
        public Matrix Projection { get; set; }
        public int AlphaFunction { get; set; }
        public int ReferenceAlpha { get; set; }
        public Vector3 DiffuseColor { get; set; }
        public float Alpha { get; set; }
        public Texture2D Texture { get; set; }
        public VertexDeclaration VertexDeclaration { get; set; }
        public bool FogEnabled { get; set; }
        public Vector3 FogColor { get; set; }
        public float FogStart { get; set; }
        public float FogEnd { get; set; }
    }

    public class DualTextureEffect : Effect, IEffectMatrices
    {
        public DualTextureEffect(GraphicsDevice device) : base(device, null) { }
        public Matrix World { get; set; }
        public Matrix View { get; set; }
        public Matrix Projection { get; set; }
        public Vector3 DiffuseColor { get; set; }
        public float Alpha { get; set; }
        public Texture2D Texture { get; set; }
        public Texture2D Texture2 { get; set; }
        public VertexDeclaration VertexDeclaration { get; set; }
    }

    public class EnvironmentMapEffect : Effect, IEffectMatrices
    {
        public EnvironmentMapEffect(GraphicsDevice device) : base(device, null) { }
        public Matrix World { get; set; }
        public Matrix View { get; set; }
        public Matrix Projection { get; set; }
        public Texture2D Texture { get; set; }
        public TextureCube EnvironmentMap { get; set; }
        public Vector3 DiffuseColor { get; set; }
        public float EnvironmentMapAmount { get; set; }
        public float FresnelFactor { get; set; }
        public Vector3 EnvironmentMapSpecular { get; set; }
        public float Alpha { get; set; }
        public void EnableDefaultLighting() { }
    }

    public class SpriteBatch : IDisposable
    {
        public SpriteBatch(GraphicsDevice device) { }
        public void Begin() { }
        public void Begin(SpriteSortMode sortMode, BlendState blendState) { }
        public void Begin(SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState) { }
        public void Begin(SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState) { }
        public void Begin(SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState) { }
        public void Begin(SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect) { }
        public void End() { }
        public void Draw(Texture2D texture, Vector2 position, Color color) { }
        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color) { }
        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth) { }
        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth) { }
        public void Draw(Texture2D texture, Rectangle destinationRectangle, Color color) { }
        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color) { }
        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth) { }
        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color) { }
        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth) { }
        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth) { }
        public void DrawString(SpriteFont spriteFont, System.Text.StringBuilder text, Vector2 position, Color color) { }
        public void Dispose() { }
        public bool IsDisposed => false;
    }

    public class SpriteFont
    {
        public int LineSpacing { get; set; }
        public float Spacing { get; set; }
        public Vector2 MeasureString(string text) => default;
        public Vector2 MeasureString(System.Text.StringBuilder text) => default;
        public void SetData<T>(T[] data) { }
        public char? DefaultCharacter { get; set; }
    }

    public class GraphicsDevice : IDisposable
    {
        public GraphicsDevice() { }
        public GraphicsDevice(IGraphicsDeviceService ds) { }
        public void Clear(Color color) { }
        public void Clear(ClearOptions options, Color color, float depth, int stencil) { }
        public void Present() { }
        public void Present(Rectangle? sourceRectangle, Rectangle? destinationRectangle, IntPtr overrideWindowHandle) { }
        public void SetRenderTarget(RenderTarget2D renderTarget) { }
        public void SetRenderTarget(RenderTargetBinding renderTarget) { }
        public void GetBackBufferData<T>(T[] data) where T : struct { }
        public void GetBackBufferData<T>(Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct { }
        public void DrawIndexedPrimitives(PrimitiveType primitiveType, int baseVertex, int minVertexIndex, int numVertices, int startIndex, int primitiveCount) { }
        public void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, int[] indexData, int indexOffset, int primitiveCount) where T : struct, IVertexType { }
        public void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, int[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct { }
        public void DrawPrimitives(PrimitiveType primitiveType, int vertexStart, int primitiveCount) { }
        public void DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int minVertexIndex, int numVertices, int startIndex, int primitiveCount, int instanceCount) { }
        public void Dispose() { }
        public bool IsDisposed => false;
        public bool IsBackBufferReady => false;
        public Viewport Viewport { get; set; }
        public Matrix View { get; set; }
        public Matrix Projection { get; set; }
        public PresentationParameters PresentationParameters => null;
        public GraphicsProfile GraphicsProfile => GraphicsProfile.Reach;
        public Texture2D GetBackBuffer() => null;
        public void SetVertexBuffer(VertexBuffer vertexBuffer) { }
        public void SetVertexBuffer(VertexBuffer vertexBuffer, int vertexOffset) { }
        public void SetIndexBuffer(IndexBuffer indexBuffer) { }
        public void SetVertexBuffers(params VertexBufferBinding[] bindings) { }
        public void SetBlendState(BlendState blendState) { }
        public void SetRasterizerState(RasterizerState rasterizerState) { }
        public void SetDepthStencilState(DepthStencilState depthStencilState) { }
        public void SetSamplerState(int index, SamplerState samplerState) { }
        public void SetSamplers(int index, params SamplerState[] samplers) { }
        public void SetScissorRectangle(Rectangle rect) { }
        public void SetTexture(int index, Texture texture) { }
        public void ClearDepth(float depth) { }
        public void Reset() { }
        public void Present(IntPtr overrideWindowHandle) { }
        public Rectangle ScissorRectangle { get; set; }

        public RasterizerState RasterizerState { get; set; }
        public DepthStencilState DepthStencilState { get; set; }

        public GraphicsAdapter Adapter => null;
        public void ApplyState() { }
        public void SetVertexTexture(int index, Texture texture) { }
        internal RenderTargetBinding GetRenderTargets() => null;
    }

    public struct VertexBufferBinding
    {
        public VertexBuffer VertexBuffer;
        public int VertexOffset;
        public VertexBufferBinding(VertexBuffer vertexBuffer) { VertexBuffer = vertexBuffer; VertexOffset = 0; }
        public VertexBufferBinding(VertexBuffer vertexBuffer, int vertexOffset) { VertexBuffer = vertexBuffer; VertexOffset = vertexOffset; }
    }

    public class GraphicsAdapter
    {
        public static GraphicsAdapter DefaultAdapter => null;
        public string Description => null;
        public DisplayMode CurrentDisplayMode => default;
        public DisplayModeCollection SupportedDisplayModes => null;
        public bool IsWideScreen => false;
    }

    public struct DisplayMode
    {
        public int Width, Height;
        public SurfaceFormat Format;
        public float AspectRatio => 0f;
    }

    public class DisplayModeCollection : IEnumerable<DisplayMode>
    {
        public IEnumerable<DisplayMode> this[SurfaceFormat format] => null;
        public IEnumerator<DisplayMode> GetEnumerator() => null;
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => null;
    }

    public struct Viewport
    {
        public int X, Y, Width, Height;
        public Viewport(int x, int y, int w, int h) { X = x; Y = y; Width = w; Height = h; MinDepth = 0f; MaxDepth = 1f; }
        public float MinDepth;
        public float MaxDepth;
        public Rectangle Bounds => default;
        public Rectangle TitleSafeArea => default;
        public Vector3 Project(Vector3 source, Matrix projection, Matrix view, Matrix world) => default;
        public Vector3 Unproject(Vector3 source, Matrix projection, Matrix view, Matrix world) => default;
        public Vector2 Project(Vector2 source, Matrix projection, Matrix view, Matrix world) => default;
        public Vector2 Unproject(Vector2 source, Matrix projection, Matrix view, Matrix world) => default;
    }

    public class PresentationParameters
    {
        public int BackBufferWidth { get; set; }
        public int BackBufferHeight { get; set; }
        public bool IsFullScreen { get; set; }
        public float DepthStencilFormat { get; set; }
        public SurfaceFormat BackBufferFormat { get; set; }
        public DepthFormat DepthStencilFormat2 { get; set; }
        public PresentInterval PresentationInterval { get; set; }
        public PresentInterval PresentInterval2 { get; set; }
        public int MultiSampleCount { get; set; }
        public bool IsFullScreen2 { get; set; }
        public IntPtr DeviceWindowHandle { get; set; }
        public bool VSync => false;
        public int RenderTargetUsage { get; set; }
        public RenderTargetUsage Usage { get; set; }
        public int MultiSampleMask { get; set; }
        public int BackBufferCount { get; set; }
        public DisplayOrientation DisplayOrientation { get; set; }
        public int SwapInterval { get; set; }
    }

    public enum DisplayOrientation { Default, LandscapeLeft, LandscapeRight, Portrait }
    public enum PresentInterval { One, Default, Two, Immediate }

    public enum RenderTargetUsage { DiscardContents, PreserveContents, PlatformContents }
    public enum SpriteSortMode { Deferred, Immediate, Texture, BackToFront, FrontToBack }
    public enum SpriteEffects { None, FlipHorizontally, FlipVertically, FlipHorizontallyAndVertically }
    public enum SurfaceFormat { Color, Bgr565, Bgra5551, Bgra4444, Dxt1, Dxt3, Dxt5, NormalizedByte2, NormalizedByte4, Rgba1010102, Rg32, Rgba64, Alpha8, Single, Vector2, Vector4, HalfSingle, HalfVector2, HalfVector4, HdrBlendable, ColorBgraEXT, ColorSrgbEXT, Dxt1aEXT, Bgra32EXT, Bgr32EXT }
    public enum DepthFormat { None, Depth16, Depth24, Depth24Stencil8 }
    public enum IndexElementSize { SixteenBits, ThirtyTwoBits }
    public enum BufferUsage { None, WriteOnly }
    public enum SetDataOptions { None, Discard, NoOverwrite }
    public enum PrimitiveType { TriangleList, TriangleStrip, LineList, LineStrip, PointList }
    public enum VertexElementFormat { Single, Vector2, Vector3, Vector4, Color, Byte4, Short2, Short4, NormalizedShort2, NormalizedShort4, HalfVector2, HalfVector4 }
    public enum VertexElementUsage { Position, Color, TextureCoordinate, Normal, Binormal, Tangent, BlendIndices, BlendWeight, Depth, Fog, PointSize, Sample, TessellationFactor }
    public enum CubeMapFace { PositiveX, NegativeX, PositiveY, NegativeY, PositiveZ, NegativeZ }
    public enum GraphicsProfile { Reach, HiDef }
    public enum ClearOptions { Target, DepthBuffer, Stencil, TargetAndDepthBuffer }

    public class BlendState
    {
        public static BlendState Additive { get; }
        public static BlendState AlphaBlend { get; }
        public static BlendState NonPremultiplied { get; }
        public static BlendState Opaque { get; }
        public BlendFunction AlphaBlendFunction { get; set; }
        public Blend AlphaSourceBlend { get; set; }
        public Blend AlphaDestinationBlend { get; set; }
        public BlendFunction ColorBlendFunction { get; set; }
        public Blend ColorSourceBlend { get; set; }
        public Blend ColorDestinationBlend { get; set; }
        public ColorWriteChannels ColorWriteChannels { get; set; }
        public ColorWriteChannels ColorWriteChannels1 { get; set; }
        public ColorWriteChannels ColorWriteChannels2 { get; set; }
        public ColorWriteChannels ColorWriteChannels3 { get; set; }
        public Color BlendFactor { get; set; }
        public int MultiSampleMask { get; set; }
    }
    public enum Blend { One, Zero, SourceColor, InverseSourceColor, SourceAlpha, InverseSourceAlpha, DestinationAlpha, InverseDestinationAlpha, DestinationColor, InverseDestinationColor, BlendFactor, InverseBlendFactor, SourceAlphaSaturation }
    public enum BlendFunction { Add, Subtract, ReverseSubtract, Max, Min }
    public enum ColorWriteChannels { None, Red, Green, Blue, Alpha, All }
    public enum CompareFunction { Always, Never, Less, LessEqual, Equal, GreaterEqual, Greater, NotEqual }

    public class DepthStencilState
    {
        public static DepthStencilState Default { get; }
        public static DepthStencilState DepthRead { get; }
        public static DepthStencilState None { get; }
        public bool DepthBufferEnable { get; set; }
        public bool DepthBufferWriteEnable { get; set; }
        public CompareFunction DepthBufferFunction { get; set; }
        public bool StencilEnable { get; set; }
        public CompareFunction StencilFunction { get; set; }
        public StencilOperation StencilPass { get; set; }
        public StencilOperation StencilFail { get; set; }
        public StencilOperation StencilDepthBufferFail { get; set; }
        public int StencilMask { get; set; }
        public int StencilWriteMask { get; set; }
        public int ReferenceStencil { get; set; }
        public bool TwoSidedStencilMode { get; set; }
        public CompareFunction CounterClockwiseStencilFunction { get; set; }
        public StencilOperation CounterClockwiseStencilPass { get; set; }
        public StencilOperation CounterClockwiseStencilFail { get; set; }
        public StencilOperation CounterClockwiseStencilDepthBufferFail { get; set; }
    }
    public enum StencilOperation { Keep, Zero, Replace, Increment, Decrement, IncrementSaturation, DecrementSaturation, Invert }

    public class SamplerState
    {
        public static SamplerState AnisotropicClamp { get; }
        public static SamplerState AnisotropicWrap { get; }
        public static SamplerState LinearClamp { get; }
        public static SamplerState LinearWrap { get; }
        public static SamplerState PointClamp { get; }
        public static SamplerState PointWrap { get; }
        public TextureFilter Filter { get; set; }
        public TextureAddressMode AddressU { get; set; }
        public TextureAddressMode AddressV { get; set; }
        public TextureAddressMode AddressW { get; set; }
        public int MaxAnisotropy { get; set; }
        public int MaxMipLevel { get; set; }
        public float MipMapLevelOfDetailBias { get; set; }
        public CompareFunction ComparisonFunction { get; set; }
        public float FilterMode { get; set; }
    }
    public enum TextureFilter { Point, Linear, Anisotropic }
    public enum TextureAddressMode { Clamp, Wrap, Mirror }

    public class RasterizerState
    {
        public static RasterizerState CullClockwise { get; }
        public static RasterizerState CullCounterClockwise { get; }
        public static RasterizerState CullNone { get; }
        public CullMode CullMode { get; set; }
        public FillMode FillMode { get; set; }
        public bool ScissorTestEnable { get; set; }
        public bool MultiSampleAntiAlias { get; set; }
        public float DepthBias { get; set; }
        public float SlopeScaleDepthBias { get; set; }
    }
    public enum CullMode { None, CullClockwiseFace, CullCounterClockwiseFace }
    public enum FillMode { Solid, WireFrame }

    public class GraphicsDeviceManager : IDisposable
    {
        public GraphicsDeviceManager(Microsoft.Xna.Framework.Game game) { }
        public int PreferredBackBufferWidth { get; set; }
        public int PreferredBackBufferHeight { get; set; }
        public bool IsFullScreen { get; set; }
        public bool SynchronizeWithVerticalRetrace { get; set; }
        public bool PreferMultiSampling { get; set; }
        public bool PreferHalfPixelOffset { get; set; }
        public bool HardwareModeSwitch { get; set; }
        public DepthFormat PreferredDepthStencilFormat { get; set; }
        public GraphicsProfile GraphicsProfile { get; set; }
        public Microsoft.Xna.Framework.Graphics.GraphicsDevice GraphicsDevice { get; }
        public bool IsDisposed => false;
        public void ApplyChanges() { }
        public void Dispose() { }
        public bool SupportsOrientationChange => false;
        public DisplayOrientation SupportedOrientations { get; set; }
        public IntPtr WindowHandle => IntPtr.Zero;
    }

    public class GameWindow
    {
        public string Title { get; set; }
        public bool AllowUserResizing { get; set; }
        public Rectangle ClientBounds => default;
        public IntPtr Handle => IntPtr.Zero;
        public event EventHandler ClientSizeChanged;
        public event EventHandler<EventArgs> TextInput;
        public void BeginScreenDeviceChange(bool willBeFullScreen) { }
        public void EndScreenDeviceChange(int clientWidth, int clientHeight) { }
        public void SetCursorVisible(bool visible) { }
    }

    public class GraphicsContext { }
    public class GraphicsMetrics { }
    public struct GraphicsDeviceStatus { }
}

namespace Microsoft.Xna.Framework.Graphics.PackedVector
{
    public struct HalfSingle { public float ToSingle() => 0f; }
    public struct HalfVector2 { public Vector2 ToVector2() => default; }
    public struct HalfVector4 { public Vector4 ToVector4() => default; }
    public struct NormalizedShort2 { public Vector2 ToVector2() => default; }
    public struct NormalizedShort4 { public Vector4 ToVector4() => default; }
    public struct Short2 { public Vector2 ToVector2() => default; }
    public struct Short4 { public Vector4 ToVector4() => default; }
    public struct Byte4 { public Vector4 ToVector4() => default; }
    public struct Alpha8 { }
    public struct Bgra4444 { }
    public struct Bgra5551 { }
    public struct Bgr565 { }
    public struct Rg32 { }
    public struct Rgba1010102 { }
    public struct Rgba64 { }
}

namespace Microsoft.Xna.Framework.Input
{
    public enum Keys
    {
        None = 0, Back = 8, Tab = 9, Enter = 13, Pause = 19, CapsLock = 20, Escape = 27, Space = 32,
        PageUp = 33, PageDown = 34, End = 35, Home = 36, Left = 37, Up = 38, Right = 39, Down = 40,
        Select = 41, Print = 42, Execute = 43, PrintScreen = 44, Insert = 45, Delete = 46, Help = 47,
        D0 = 48, D1 = 49, D2 = 50, D3 = 51, D4 = 52, D5 = 53, D6 = 54, D7 = 55, D8 = 56, D9 = 57,
        A = 65, B = 66, C = 67, D = 68, E = 69, F = 70, G = 71, H = 72, I = 73, J = 74, K = 75, L = 76,
        M = 77, N = 78, O = 79, P = 80, Q = 81, R = 82, S = 83, T = 84, U = 85, V = 86, W = 87, X = 88,
        Y = 89, Z = 90, LeftWindows = 91, RightWindows = 92, Apps = 93, Sleep = 95,
        NumPad0 = 96, NumPad1 = 97, NumPad2 = 98, NumPad3 = 99, NumPad4 = 100, NumPad5 = 101,
        NumPad6 = 102, NumPad7 = 103, NumPad8 = 104, NumPad9 = 105, Multiply = 106, Add = 107,
        Separator = 108, Subtract = 109, Decimal = 110, Divide = 111, F1 = 112, F2 = 113, F3 = 114,
        F4 = 115, F5 = 116, F6 = 117, F7 = 118, F8 = 119, F9 = 120, F10 = 121, F11 = 122, F12 = 123,
        F13 = 124, F14 = 125, F15 = 126, F16 = 127, F17 = 128, F18 = 129, F19 = 130, F20 = 131,
        F21 = 132, F22 = 133, F23 = 134, F24 = 135, NumLock = 144, Scroll = 145,
        LeftShift = 160, RightShift = 161, LeftControl = 162, RightControl = 163, LeftAlt = 164,
        RightAlt = 165, BrowserBack = 166, BrowserForward = 167, BrowserRefresh = 168, BrowserStop = 169,
        BrowserSearch = 170, BrowserFavorites = 171, BrowserHome = 172, VolumeMute = 173,
        VolumeDown = 174, VolumeUp = 175, MediaNextTrack = 176, MediaPreviousTrack = 177,
        MediaStop = 178, MediaPlayPause = 179, LaunchMail = 180, SelectMedia = 181, LaunchApplication1 = 182,
        LaunchApplication2 = 183, OemSemicolon = 186, OemPlus = 187, OemComma = 188, OemMinus = 189,
        OemPeriod = 190, OemQuestion = 191, OemTilde = 192, ChatPadGreen = 202, ChatPadOrange = 203,
        OemOpenBrackets = 219, OemPipe = 220, OemCloseBrackets = 221, OemQuotes = 222, Oem8 = 223,
        OemBackslash = 226, ProcessKey = 229, Attn = 246, Crsel = 247, Exsel = 248, EraseEof = 249,
        Play = 250, Zoom = 251, NoName = 252, Pa1 = 253, OemClear = 254,
        BigEnter = 159, SoftLeft = 160, SoftRight = 161, MobileBack = 162, MobileMenu = 200
    }

    public struct KeyboardState
    {
        public KeyboardState(params Keys[] keys) { }
        public KeyState this[Keys key] => KeyState.Up;
        public bool IsKeyDown(Keys key) => false;
        public bool IsKeyUp(Keys key) => false;
        public Keys[] GetPressedKeys() => null;
        public static bool operator ==(KeyboardState a, KeyboardState b) => false;
        public static bool operator !=(KeyboardState a, KeyboardState b) => false;
        public override bool Equals(object obj) => false;
        public override int GetHashCode() => 0;
    }
    public enum KeyState { Up, Down }

    public struct MouseState
    {
        public int X => 0;
        public int Y => 0;
        public int ScrollWheelValue => 0;
        public ButtonState LeftButton => ButtonState.Released;
        public ButtonState RightButton => ButtonState.Released;
        public ButtonState MiddleButton => ButtonState.Released;
        public ButtonState XButton1 => ButtonState.Released;
        public ButtonState XButton2 => ButtonState.Released;
        public bool IsRelativeMouseModeEXT => false;
        public static bool operator ==(MouseState a, MouseState b) => false;
        public static bool operator !=(MouseState a, MouseState b) => false;
        public override bool Equals(object obj) => false;
        public override int GetHashCode() => 0;
    }
    public enum ButtonState { Released, Pressed }

    public struct GamePadState
    {
        public bool IsConnected => false;
        public GamePadButtons Buttons => default;
        public GamePadThumbSticks ThumbSticks => default;
        public GamePadTriggers Triggers => default;
        public GamePadDPad DPad => default;
        public bool IsButtonDown(Buttons button) => false;
        public bool IsButtonUp(Buttons button) => false;
    }
    public struct GamePadButtons
    {
        public ButtonState A => ButtonState.Released;
        public ButtonState B => ButtonState.Released;
        public ButtonState X => ButtonState.Released;
        public ButtonState Y => ButtonState.Released;
        public ButtonState Back => ButtonState.Released;
        public ButtonState Start => ButtonState.Released;
        public ButtonState BigButton => ButtonState.Released;
    }
    public struct GamePadThumbSticks
    {
        public Vector2 Left => default;
        public Vector2 Right => default;
    }
    public struct GamePadTriggers
    {
        public float Left => 0f;
        public float Right => 0f;
    }
    public struct GamePadDPad { }
    [Flags]
    public enum Buttons
    {
        None = 0, DPadUp = 1, DPadDown = 2, DPadLeft = 4, DPadRight = 8, Start = 16, Back = 32,
        LeftStick = 64, RightStick = 128, LeftShoulder = 256, RightShoulder = 512, BigButton = 1024,
        A = 4096, B = 8192, X = 16384, Y = 32768
    }
    public static class Mouse { public static MouseState GetState() => default; public static void SetPosition(int x, int y) { } }
    public static class Keyboard { public static KeyboardState GetState() => default; }
    public static class GamePad { public static GamePadState GetState(PlayerIndex i) => default; public static bool SetVibration(PlayerIndex i, float l, float r) => false; public static void SetLightBarEXT(PlayerIndex i, Color c) { } }
    public enum PlayerIndex { One, Two, Three, Four }
}

namespace Microsoft.Xna.Framework.Audio
{
    public class SoundEffect : IDisposable
    {
        public SoundEffect(byte[] buffer, int sampleRate, AudioChannels channels) { }
        public SoundEffect(byte[] buffer, int offset, int count, int sampleRate, AudioChannels channels, int loopStart, int loopLength) { }
        public TimeSpan Duration => default;
        public bool IsDisposed => false;
        public static SoundEffect FromStream(System.IO.Stream stream) => null;
        public static float MasterVolume { get; set; }
        public static float DistanceScale { get; set; }
        public static float DopplerScale { get; set; }
        public static float SpeedOfSound { get; set; }
        public SoundEffectInstance CreateInstance() => null;
        public bool Play() => false;
        public bool Play(float volume, float pitch, float pan) => false;
        public void Dispose() { }
    }

    public class SoundEffectInstance : IDisposable
    {
        public bool IsLooped { get; set; }
        public float Volume { get; set; }
        public float Pitch { get; set; }
        public float Pan { get; set; }
        public SoundState State => SoundState.Stopped;
        public bool IsDisposed => false;
        public void Play() { }
        public void Pause() { }
        public void Resume() { }
        public void Stop() { }
        public void Stop(bool immediate) { }
        public void Apply3D(AudioListener listener, AudioEmitter emitter) { }
        public void Apply3D(AudioListener[] listeners, AudioEmitter emitter) { }
        public void Dispose() { }
    }

    public class SoundEffectInstancePool { }
    public enum SoundState { Playing, Paused, Stopped }

    public class AudioListener
    {
        public Vector3 Position { get; set; }
        public Vector3 Forward { get; set; }
        public Vector3 Up { get; set; }
        public Vector3 Velocity { get; set; }
    }

    public class AudioEmitter
    {
        public Vector3 Position { get; set; }
        public Vector3 Forward { get; set; }
        public Vector3 Up { get; set; }
        public Vector3 Velocity { get; set; }
        public float DopplerScale { get; set; }
    }

    public class DynamicSoundEffectInstance : SoundEffectInstance
    {
        public DynamicSoundEffectInstance(int sampleRate, AudioChannels channels) { }
        public int PendingBufferCount => 0;
        public int TargetPendingBufferCount { get; set; }
        public event EventHandler<EventArgs> BufferNeeded;
        public void SubmitBuffer(byte[] buffer) { }
        public void SubmitBuffer(byte[] buffer, int offset, int count) { }
    }

    public enum AudioChannels { Mono = 1, Stereo = 2 }

    public class SoundEffectMastering { }
    public class WaveBank : IDisposable
    {
        public WaveBank(System.IO.Stream stream) { }
        public WaveBank(System.IO.Stream stream, int offset, short packetsize) { }
        public void Dispose() { }
    }

    public class SoundBank : IDisposable
    {
        public SoundBank(System.IO.Stream stream) { }
        public SoundBank(System.IO.Stream stream, int offset, int size) { }
        public Cue GetCue(string name) => null;
        public void PlayCue(string name) { }
        public void PlayCue(string name, AudioListener listener, AudioEmitter emitter) { }
        public void Dispose() { }
    }

    public class Cue : IDisposable
    {
        public bool IsPlaying => false;
        public bool IsPaused => false;
        public bool IsStopped => false;
        public bool IsLooped => false;
        public bool IsDisposing => false;
        public string Name => null;
        public float Volume { get; set; }
        public void Apply3D(AudioListener listener, AudioEmitter emitter) { }
        public void Play() { }
        public void Pause() { }
        public void Resume() { }
        public void Stop(AudioStopOptions options) { }
        public void Dispose() { }
    }
    public enum AudioStopOptions { AsAuthored, Immediate }

    public static class MediaPlayer
    {
        public static bool IsMuted { get; set; }
        public static float Volume { get; set; }
        public static bool IsRepeating { get; set; }
        public static bool IsVisualizationEnabled => false;
        public static void Play(Song song) { }
        public static void Pause() { }
        public static void Resume() { }
        public static void Stop() { }
    }

    public class Song : IDisposable
    {
        public static Song FromUri(string name, System.Uri uri) => null;
        public bool IsDisposed => false;
        public bool IsProtected => false;
        public TimeSpan Duration => default;
        public string Name => null;
        public bool IsPlaying => false;
        public void Dispose() { }
    }

    public class AudioEngine : IDisposable
    {
        public AudioEngine() { }
        public AudioEngine(string settingsFile) { }
        public void Update() { }
        public void Dispose() { }
    }
}

namespace Microsoft.Xna.Framework.Content
{
    public class ContentManager : IDisposable
    {
        public ContentManager(IServiceProvider serviceProvider, string rootDirectory) { }
        public T Load<T>(string assetName) => default;
        public void Unload() { }
        public void Dispose() { }
        public string RootDirectory { get; set; }
    }
    public class ContentReader { }
    public class ContentTypeReader { }
    public class ContentSerializerAttribute : Attribute { }
    public abstract class ContentTypeReader<T> : ContentTypeReader { }
}

namespace Microsoft.Xna.Framework
{
    public class Game : IDisposable
    {
        public Game() { }
        public Microsoft.Xna.Framework.Graphics.GraphicsDevice GraphicsDevice => null;
        public GameTime TotalGameTime => null;
        public bool IsActive => false;
        public bool IsMouseVisible { get; set; }
        public Microsoft.Xna.Framework.Graphics.GameWindow Window => null;
        public Microsoft.Xna.Framework.Content.ContentManager Content => null;
        public void Exit() { }
        public void Dispose() { }
        public void Run() { }
        public void RunOneFrame() { }
        protected virtual void Initialize() { }
        protected virtual void LoadContent() { }
        protected virtual void UnloadContent() { }
        protected virtual void Update(GameTime gameTime) { }
        protected virtual void Draw(GameTime gameTime) { }
        protected virtual void BeginRun() { }
        protected virtual void EndRun() { }
        protected virtual void OnActivated(object sender, EventArgs args) { }
        protected virtual void OnDeactivated(object sender, EventArgs args) { }
        protected virtual void OnExiting(object sender, EventArgs args) { }
        protected virtual bool BeginDraw() => false;
        protected virtual void EndDraw() { }
        public bool IsFixedTimeStep { get; set; }
        public TimeSpan TargetElapsedTime { get; set; }
        public TimeSpan MaxElapsedTime { get; set; }
        public bool SuppressDraw() => false;
        public void DoEvents() { }
        public void Tick() { }
        public bool IsRunningSlowly => false;
        public bool IsExiting => false;
        public event EventHandler<EventArgs> Activated;
        public event EventHandler<EventArgs> Deactivated;
        public event EventHandler<EventArgs> Disposed;
        public event EventHandler<EventArgs> Exiting;
        public event EventHandler<EventArgs> Idle;
    }

    public struct GameComponentCollectionEventArgs { }

    public static class FrameworkDispatcher
    {
        public static void Update() { }
    }

    public class GraphicsDeviceInformation { }

    public interface IGraphicsDeviceService
    {
        Microsoft.Xna.Framework.Graphics.GraphicsDevice GraphicsDevice { get; }
        event EventHandler<EventArgs> DeviceCreated;
        event EventHandler<EventArgs> DeviceDisposing;
        event EventHandler<EventArgs> DeviceReset;
        event EventHandler<EventArgs> DeviceResetting;
    }

    public interface IGraphicsDeviceManager
    {
        bool BeginDraw();
        void CreateDevice();
        void EndDraw();
        bool IsDeviceReady { get; }
    }

    public class GamerServices { }
    public class StorageContainer { }
    public interface IServiceProvider { }
    public class GameServiceContainer { }
}
using System;

namespace SMokaEngine
{
    public struct Vector3
    {
        public float x;
		public float y;
		public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float SqrLength()
        {
            return x * x + y * y;
        }

        public float Length()
        {
            return (float) Math.Sqrt(SqrLength());
        }

        public Vector3 Normalize()
        {
            float len = Length();
            x /= len;
            y /= len;
            z /= len;
            return this;
        }

        public Vector3 Normalized()
        {
            float len = Length();
            return new Vector3(x / len, y / len, z / len);
        }

        public Vector3 Cross(Vector3 o)
        {
            return new Vector3(y * o.z - z * o.y, z * o.x - x * o.z, x * o.y - y * o.x);
        }

        public static Vector3 operator +(Vector3 t, Vector3 o)
        {
            return new Vector3(t.x + o.x, t.y + o.y, t.z + o.z);
        }

        public static Vector3 operator -(Vector3 t, Vector3 o)
        {
            return new Vector3(t.x - o.x, t.y - o.y, t.z - o.z);
        }

        public static Vector3 operator *(Vector3 t, Vector3 o)
        {
            return new Vector3(t.x * o.x, t.y * o.y, t.z * o.z);
        }

        public static Vector3 operator /(Vector3 t, Vector3 o)
        {
            return new Vector3(t.x / o.x, t.y / o.y, t.z / o.z);
        }

        public static bool operator ==(Vector3 t, Vector3 o)
        {
            return t.x == o.x && t.y == o.y && t.z == o.z;
        }

        public static bool operator !=(Vector3 t, Vector3 o)
        {
            return t.x != o.x || t.y != o.y || t.z != o.z;
        }

        public static implicit operator Vector2(Vector3 t)
        {
            return new Vector2(t.x, t.y);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Vector3))
            {
                Vector3 v = (Vector3) obj;
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", x, y, z);
        }
    }
}


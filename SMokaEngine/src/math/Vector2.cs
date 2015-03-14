using System;

namespace SMokaEngine
{
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float SqrLenght()
        {
            return x * x + y * y;
        }

        public float Length()
        {
            return (float) Math.Sqrt(SqrLenght());
        }

        public float Dot(Vector2 o)
        {
            return x * o.x + y * o.y;
        }

        public Vector2 Normalize()
        {
            float len = Length();
            x /= len;
            y /= len;
            return this;
        }

        public float Angle()
        {
            return (float) Math.Atan2(y, x);
        }

        public Vector2 Normalized()
        {
            float len = Length();
            return new Vector2(x / len, y / len);
        }

		public Vector2 Add(float x, float y)
		{
			this.x += x;
			this.y += y;
			return this;
		}

        public static Vector2 operator +(Vector2 t, Vector2 o)
        {
            return new Vector2(t.x + o.x, t.y + o.y);
        }

        public static Vector2 operator -(Vector2 t, Vector2 o)
        {
            return new Vector2(t.x - o.x, t.y - o.y);
        }

        public static Vector2 operator *(Vector2 t, Vector2 o)
        {
            return new Vector2(t.x * o.x, t.y * o.y);
        }

        public static Vector2 operator /(Vector2 t, Vector2 o)
        {
            return new Vector2(t.x / o.x, t.y / o.y);
        }

        public static bool operator ==(Vector2 t, Vector2 o)
        {
			return Math.Abs(t.x - o.x) < float.Epsilon && Math.Abs(t.y - o.y) < float.Epsilon;
        }

        public static bool operator !=(Vector2 t, Vector2 o)
        {
			return Math.Abs(t.x - o.x) > float.Epsilon || Math.Abs(t.y - o.y) > float.Epsilon;
        }

        public static implicit operator Vector3(Vector2 t)
        {
            return new Vector3(t.x, t.y, 0);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Vector2))
            {
                Vector2 v = (Vector2) obj;
                return this == v;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", x, y);
        }
    }
}


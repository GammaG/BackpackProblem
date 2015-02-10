using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpack
{
    class BackpackObject : IComparable<BackpackObject>
    {
         private int index;
            private float weight, value;

            public BackpackObject(int index, float weight, float value)
            {
                this.index = index;
                this.weight = weight;
                this.value = value;
            }

            public int CompareTo(BackpackObject other)
            {
                float diff = this.value / this.weight - other.value / other.weight;
                return diff > 0f ? 1 : (diff < 0f ? -1 : 0);
            }

            public override String ToString()
            {
                return "Objekt " + this.index + ": " +
                    this.weight.ToString(Constants.FORMAT_PROVIDER) + " " + this.value.ToString(Constants.FORMAT_PROVIDER);
            }
            public float Weight { get { return weight; } }

    }
}

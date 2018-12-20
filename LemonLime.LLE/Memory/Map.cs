﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LemonLime.LLE
{
    class Map
    {
        public delegate void PhysFunc(Context Ctx);

        public uint     Address;
        public uint     Size;
        public byte[]   Phys;
        public PhysFunc PhysCallback;

        public Map(uint Address, uint Size,
            byte[] Phys = null, PhysFunc PhysCallback = null)
        {
            this.Address = Address;
            this.Size    = Size;

            if (Phys != null)
            {
                if (Phys.Length > Size)
                    throw new Exception("Physical memory array in function parameter is bigger than size variable in function parameter.");

                this.Phys = Phys;
            }
            else
            {
                if (PhysCallback != null)
                {
                    this.PhysCallback = PhysCallback;
                    return;
                }

                this.Phys = new byte[Size];
            }
        }
    }
}
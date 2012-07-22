﻿// originally made by caytchen https://github.com/caytchen/cleanCore/tree/6da9071f5ea74a10697a0461074d5c2154f1d354/cleanPattern
// modified by HighVoltz to work out of process
/*
#######################    Simplified BSD License    ########################
# Redistribution and use in source and binary forms, with or without 
# modification, are permitted provided that the following conditions are met:
#    * Redistributions of source code must retain the above copyright 
#      notice, this list of conditions and the following disclaimer.
#    * Redistributions in binary form must reproduce the above copyright 
#      notice, this list of conditions and the following disclaimer in the
#      documentation and/or other materials provided with the 
#      distribution.
# THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS 
# IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
# TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
# PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
# HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
# SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED 
# TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
# PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF 
# LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
# NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS 
# SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#*/

using System.IO;
using Magic;

namespace HighVoltz.HBRelog.CleanPattern
{
    public enum LeaType
    {
        Byte,
        Word,
        Dword
    }

    public class LeaModifier : IModifier
    {
        public LeaType Type { get; private set; }

        public LeaModifier()
        {
            Type = LeaType.Dword;
        }

        public LeaModifier(LeaType type)
        {
            Type = type;
        }

        public uint Apply(BlackMagic bm, uint address)
        {
            switch (Type)
            {
                case LeaType.Byte:
                    return bm.ReadByte(address);
                case LeaType.Word:
                    return bm.ReadUShort(address);
                case LeaType.Dword:
                    return bm.ReadUInt(address);
            }
            throw new InvalidDataException("Unknown LeaType");
        }
    }
}
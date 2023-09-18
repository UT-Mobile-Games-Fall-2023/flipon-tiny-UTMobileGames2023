﻿/////////////////////////////////////////////////////////////////////////////////
//
// Photoshop PSD FileType Plugin for Paint.NET
//
// This software is provided under the MIT License:
//   Copyright (c) 2006-2007 Frank Blumenberg
//   Copyright (c) 2010-2017 Tao Yue
//
// See LICENSE.txt for complete licensing and attribution information.
//
/////////////////////////////////////////////////////////////////////////////////

namespace PhotoshopFile
{
  /// <summary>
  /// Stores the raw data for unimplemented image resource types.
  /// </summary>
  public class RawImageResource : ImageResource
  {
    public byte[] Data { get; private set; }

    private ResourceID id;
    public override ResourceID ID => id;

    public RawImageResource(ResourceID resourceId, string name)
      : base(name)
    {
      this.id = resourceId;
    }

    public RawImageResource(PsdBinaryReader reader, string signature, 
      ResourceID resourceId, string name, int numBytes)
      : base(name)
    {
      this.Signature = signature;
      this.id = resourceId;
      Data = reader.ReadBytes(numBytes);
    }
  }
}

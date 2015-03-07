﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopoJSON.Net.Geometry
{
    using GeoJSON.Net;
    using GeoJSON.Net.Converters;
    using GeoJSON.Net.Geometry;
    using Newtonsoft.Json;

    /// <summary>
    /// The topology type is the root for all TopoJSON objects and 
    /// encapsulates objects and arcs.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Topology : TopoJSONObject, IGeometryObject
    {
        #region ---------- Objects ----------
        /// <summary>
        /// The list of arcs.
        /// </summary>
        [JsonProperty(PropertyName = "objects", Required = Required.Default, Order = 50)]
        [JsonConverter(typeof(TopoJSONObjectsConverter))]
        public List<IGeometryObject> Objects { get; set; }
        #endregion

        #region ---------- Arcs ----------
        private List<Arc> _arcs;

        /// <summary>
        /// The list of arcs.
        /// </summary>
        [JsonProperty(PropertyName = "arcs", Required = Required.Always, Order = 100)]
        [JsonConverter(typeof(ArcsConverter))]
        public List<Arc> Arcs
        {
            get { return _arcs; }
            set { _arcs = value; }
        }
        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Topology() {
            this.Type = GeoJSONObjectType.Topology;
        }
    }
}

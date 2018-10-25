﻿namespace Microsoft.AspNet.OData
{
#if !WEBAPI
    using Microsoft.AspNetCore.Mvc;
#endif
    using Microsoft.OData.Edm;
#if WEBAPI
    using Microsoft.Web.Http;
#endif
    using System;
    using System.Diagnostics.Contracts;

    struct EdmTypeKey : IEquatable<EdmTypeKey>
    {
        readonly int hashCode;

        internal EdmTypeKey( IEdmStructuredType type, ApiVersion apiVersion )
        {
            Contract.Requires( type != null );
            Contract.Requires( apiVersion != null );

            hashCode = ComputeHash( type.FullTypeName(), apiVersion );
        }

        internal EdmTypeKey( IEdmTypeReference type, ApiVersion apiVersion )
        {
            Contract.Requires( type != null );
            Contract.Requires( apiVersion != null );

            hashCode = ComputeHash( type.FullName(), apiVersion );
        }

        public static bool operator ==( EdmTypeKey obj, EdmTypeKey other ) => obj.Equals( other );

        public static bool operator !=( EdmTypeKey obj, EdmTypeKey other ) => !obj.Equals( other );

        public override int GetHashCode() => hashCode;

        public override bool Equals( object obj ) => obj is EdmTypeKey other && Equals( other );

        public bool Equals( EdmTypeKey other ) => hashCode == other.hashCode;

        static int ComputeHash( string fullName, ApiVersion apiVersion )
        {
            Contract.Requires( !string.IsNullOrEmpty( fullName ) );
            Contract.Requires( apiVersion != null );

            return ( fullName.GetHashCode() * 397 ) ^ apiVersion.GetHashCode();
        }
    }
}
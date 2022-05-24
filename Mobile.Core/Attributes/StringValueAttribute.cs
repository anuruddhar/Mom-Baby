#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Core
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion	  


namespace Mobile.Core.Attributes {
    public sealed class StringValueAttribute : Attribute {
        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }
        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value) {
            this.StringValue = value;
        }
    }
}

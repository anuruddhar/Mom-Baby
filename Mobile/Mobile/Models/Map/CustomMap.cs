#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   model
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
11/03/2022          	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using System.Collections.Generic;
using Xamarin.Forms.Maps;
#endregion	  

namespace Mobile.Models.Map {
    public class CustomMap : Xamarin.Forms.Maps.Map {
        public List<CustomPin> CustomPins { get; set; } = new List<CustomPin>();
        public List<Position> RouteCoordinates { get; set; } = new List<Position>();
        public CustomMap() {
        }
    }
}

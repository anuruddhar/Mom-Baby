#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Common
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
18/02/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace

#endregion

namespace Mobile.Enum {


    public enum TransitionType {
        /// <summary>
        /// Do not animate the transition.
        /// </summary>
        None = -1,

        /// <summary>
        /// Let the OS decide how to animate the transition.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Show a fade transition animation.
        /// </summary>
        Fade = 1,

        /// <summary>
        /// Show a flip transition animation.
        /// </summary>
        Flip = 2,

        /// <summary>
        /// Show a scale transition animation.
        /// </summary>
        Scale = 3,

        /// <summary>
        /// Show a slide form left transition animation.
        /// </summary>
        SlideFromLeft = 4,

        /// <summary>
        /// Show a slide form right transition animation.
        /// </summary>
        SlideFromRight = 5,

        /// <summary>
        /// Show a slide form top transition animation.
        /// </summary>
        SlideFromTop = 6,

        /// <summary>
        /// Show a slide form bottom transition animation.
        /// </summary>
        SlideFromBottom = 7
    }

    public enum MessageType {
        Error,
        Warning,
        Message,
        Validation,
        Sucesss,
        Question,
        Nothing
    }

    public enum ConnectionSelection {
        Connect,
        WorkOffline,
        TryLater
    }


    public enum ProcessStatus {
        Open,
        InProgress,
        Finished
    }

    public enum Satisfaction {
        Notavailable = 0,
        High = 1,
        Medium = 2,
        Low = 3,
        Skip = 4
    }




}

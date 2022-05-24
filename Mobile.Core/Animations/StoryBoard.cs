
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
using Mobile.Core.Animations.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
#endregion

namespace Mobile.Core.Animations
{
    [ContentProperty("Animations")]
    public class StoryBoard : AnimationBase {
        public StoryBoard() {
            Animations = new List<AnimationBase>();
        }

        public StoryBoard(List<AnimationBase> animations) {
            Animations = animations;
        }

        public List<AnimationBase> Animations {
            get;
        }

        protected override async Task BeginAnimation() {
            foreach (var animation in Animations) {
                if (animation.Target == null)
                    animation.Target = Target;

                await animation.Begin();
            }
        }

        protected override async Task ResetAnimation() {
            foreach (var animation in Animations) {
                if (animation.Target == null)
                    animation.Target = Target;

                await animation.Reset();
            }
        }
    }
}

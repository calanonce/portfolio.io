using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    // Start is called before the first frame update
    
        public float bobbingSpeed = 0.18f;
        public float bobbingHeight = 0.2f;
        public float midpoint = 1.8f;
        private float timer = 0.0f;

        void Update(){
            float waveslice = 0.0f;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 cSharpConversion = transform.localPosition;

            if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0){
                timer = 0.0f;
            }else{
                waveslice = Mathf.Sin(timer);
                timer = timer + bobbingSpeed;
                if ( timer > Mathf.PI * 2){
                    timer = timer - (Mathf.PI * 2);

                }

            }
            if (waveslice != 0){
                float translateChange = waveslice * bobbingHeight;
                float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
                totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
                translateChange = totalAxes * translateChange;
                cSharpConversion.y = midpoint + translateChange;
            }else{
                cSharpConversion.y = midpoint;
            }
            transform.localPosition = cSharpConversion;
        }

}



using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class walk : MonoBehaviour

{

    public float auxiliar;
    bool paradireita = true;

    public float Speed;

    Rigidbody2D  body;

    public Animator anim;

    // Start is called before the first frame update

    void Start()

    {

        body = gameObject.GetComponent<Rigidbody2D>();

        anim = gameObject.GetComponent<Animator>();

        Speed = 1.2f;

    }



    // Update is called once per frame

    void FixedUpdate()

    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);

        transform.position += movement * Time.deltaTime * Speed;


        auxiliar = movement.x;
        if(movement.x > 0.1 || movement.x < -0.1){

            if(movement.x > 0.1 && paradireita == false){

                Flip();

            } else {

                if(movement.x< -0.1 && paradireita == true){

                    Flip();

                }

            }
               anim.SetBool("Parado", false);


        }else{

          anim.SetBool("Parado", true);

        }
            

      



        if(Input.GetButtonDown("Jump")){
            
            body.AddForce(new Vector2(0f,6),ForceMode2D.Impulse);

        }



    }



    void Flip(){

        paradireita = !paradireita;

        Vector3 escala = transform.localScale;

        escala.x *= -1;

        transform.localScale = escala;

    }

}

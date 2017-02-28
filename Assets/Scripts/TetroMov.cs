using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetroMov : MonoBehaviour
{
    public bool podeRodar;
    public bool roda360;
	
	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (PosicaoValida())
            {

            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (PosicaoValida())
            {

            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0,-1, 0);

            if (PosicaoValida())
            {

            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChecaRoda();
        }
    }

    void ChecaRoda()
    {
        if (podeRodar)
        {
            if (!roda360)
            {
                if(transform.rotation.z < 0)
                {
                    transform.Rotate(0, 0, 90);

                    if (PosicaoValida())
                    {

                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                } else
                {
                    transform.Rotate(0, 0, -90);

                    if (PosicaoValida())
                    {

                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);
                    }
                }
            }
            else
            {
                transform.Rotate(0, 0, -90);

                if (PosicaoValida())
                {

                }
                else
                {
                    transform.Rotate(0, 0, 90);
                }
            }
        }
    }

    bool PosicaoValida()
    {
        foreach (Transform child in transform)
        {
            Vector2 posBloco = FindObjectOfType<GameManager>().Arredonda(child.position);

            if (!FindObjectOfType<GameManager>().DentroGrade(posBloco))
            {
                return false;
            }
        }

        return true;
    }
}

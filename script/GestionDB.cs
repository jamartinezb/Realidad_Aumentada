using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionDB: MonoBehaviour
{
	public InputField txtUsuario;
	public InputField txtClave;


	public	static GestionDB	singleton;



	void 	Awake()
	{
		if	(singleton	== null)
		{
			singleton	= this; 
		}else {
             Destroy (gameObject);
				}
			}
		
	public	void Start(){

	DontDestroyOnLoad(this.gameObject);
 	}
	
	public void iniciarSesion()
	{		
		StartCoroutine (Login());
		StartCoroutine (Datos());
	
	}


IEnumerator Login(){
	WWW coneccion = new WWW ("http://localhost:8080/admin/login.php?uss=" + txtUsuario.text + "&pss=" + txtClave.text);
	yield return(coneccion);
	//Debug.Log(coneccion.text);
	if (coneccion.text == "200")
	{
		print (	"el usuario si existe");
	
	}else if (coneccion.text == "401")
	{
		print (	" contraseña incorrectos");

	}else {
			print (	"error conexion");
		
	}
 
   }

IEnumerator Datos()
   {
	WWW coneccion = new WWW ("http://localhost:8080/admin/login.php?uss=" + txtUsuario.text + "&pss=" + txtClave.text);
	yield return(coneccion);
	//Debug.Log(coneccion.text);
 if (coneccion.text == "200"){

 	SceneManager.LoadScene("Realidad");
		

	}else if(coneccion.text == "401"){
			
print (	"usuario incorrectos");

					
			}	
		
	
else {
			print (	"error conexion");
		
	}
    
  	
  }
  }
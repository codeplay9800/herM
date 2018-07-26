using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RemyController : MonoBehaviour {
	public GameObject player;
	public GameObject HitText;
	public GameObject arrow;
	bool reached;
	Animator Remy;
	NavMeshAgent agent;
	public GameObject target;
	public GameObject Dialoguebox;
	public GameObject text;
	Text txt;
	Scene scene;
	// Use this for initialization
	void Start () {
	scene = SceneManager.GetActiveScene();
	txt=text.GetComponent<Text>();
	Dialoguebox.SetActive(false);
	agent = GetComponent<NavMeshAgent>();
	Remy=gameObject.GetComponent<Animator>();
	arrow.SetActive(false);
	HitText.SetActive(false);
	Invoke("Walk",5.0f);
	reached=false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator Talk()
    {	yield return new WaitForSeconds(4.0f);
		Remy.SetBool("idle",false);
		gameObject.transform.LookAt(player.transform);
		Dialoguebox.SetActive(true);
		txt.text="Hey!!!";
		Remy.SetTrigger("talk");
        yield return new WaitForSeconds(4.0f);
		Remy.SetTrigger("talk");
		txt.text="Yes!!"+"\n You Over There";
		Remy.SetTrigger("talk");
        yield return new WaitForSeconds(4.0f);
		Remy.SetTrigger("talk");
		txt.text="Won't You come with me";
        yield return new WaitForSeconds(4.0f);
		Remy.SetTrigger("talk");
		txt.text="Come On!! \n"+"Don't be shy";
		yield return new WaitForSeconds(4.0f);
		Dialoguebox.SetActive(false);
		arrow.SetActive(true);
		HitText.SetActive(true);
        
    }
	IEnumerator Talk2()
    {	yield return new WaitForSeconds(4.0f);
		Remy.SetBool("idle",false);
		gameObject.transform.LookAt(player.transform);
		Dialoguebox.SetActive(true);
		txt.text="Hey!!!";
		Remy.SetTrigger("talk");
        yield return new WaitForSeconds(4.0f);
		Remy.SetTrigger("talk");
		txt.text="You Over There"+"\n Follow Me ";
		Remy.SetTrigger("talk");
        yield return new WaitForSeconds(4.0f);
		Remy.SetTrigger("talk");
		txt.text="If You Shout I Will Hurt You";
        yield return new WaitForSeconds(4.0f);
		Remy.SetTrigger("talk");
		txt.text="Hurry Up!! \n"+"Don't do anything Silly";
		yield return new WaitForSeconds(4.0f);
		Dialoguebox.SetActive(false);
		arrow.SetActive(true);
		HitText.SetActive(true);
        
    }

	void Walk()
	{
		Remy.SetBool("walk",true);
        agent.destination = target.transform.position;
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="target")
		{
		Remy.SetBool("idle",true);

		if(scene.name=="Scene1")
		{
		StartCoroutine("Talk");
		}
		if(scene.name=="Scene2")
		{
		StartCoroutine("Talk2");
		}
		Destroy(other.gameObject);
		}
		
	}

	

}

using UnityEngine;
using System.Collections;
using System;
using System.Xml;
using System.Xml.Serialization;

[Serializable()]
public class Game  {
	[XmlAttribute ("Position X")]
	public float x;
	[XmlAttribute ("Position Y")]
	public float y;
	[XmlAttribute ("Position Z")]
	public float z;
	//[XmlAttribute ("Rotation")]
	//public Quaternion rotation;
	[XmlAttribute("Scene")]
	public String scene;

	public Game(){
		
	}

	public Game(float x,float y,float z,string scene){
		this.x = x;
		this.y = y;
		this.z = z;
		//this.rotation = rotation;
		this.scene = scene;
	}


}

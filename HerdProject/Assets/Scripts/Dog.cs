﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
  // Start is called before the first frame update
  new void Start()
  {
    base.Start();
    animalType = AnimalType.Dog;
  }

  // Update is called once per frame
  void Update()
  {

  }
}

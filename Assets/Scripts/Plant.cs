/**
 * BSD 3-Clause License
 *
 * Copyright(c) 2020, John Pennycook
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 * * Redistributions of source code must retain the above copyright notice, this
 *   list of conditions and the following disclaimer.
 *
 * * Redistributions in binary form must reproduce the above copyright notice,
 *   this list of conditions and the following disclaimer in the documentation
 *   and/or other materials provided with the distribution.
 *
 * * Neither the name of the copyright holder nor the names of its
 *   contributors may be used to endorse or promote products derived from
 *   this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED.IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public enum Fertilizer
    {
        Acid,
        Alkali
    }

    // Current state of the plant
    public string given_name = null;
    public int age = 0;
    public float pH = 6.95f;
    public float moisture = 0.0f;
    public float health = 100.0f;
    public int happiness = 0;

    // Update the state of the plant
    // Return true if the plant is still alive
    public bool Age()
    {
        age += 1;

        // Check against ideal soil qualities        
        if (pH < 6 || pH > 7)
        {
            happiness -= 1;
            health -= 10;
        }
        else
        {
            health += 5;
        }

        if (moisture >= 0.5f)
        {
            happiness -= 1;
            health -= 10;
        }
        else
        {
            health += 5;
        }
        health = Mathf.Clamp(health, 0.0f, 100.0f);

        // A really happy plant will attempt to cling to life
        if (health == 0)
        {
            float chance = Random.Range(0, happiness);
            if (chance <= happiness)
            {
                health += 10;
                happiness -= 1;
            }
        }

        // Degrade soil quality
        pH -= 0.05f;
        moisture -= 0.1f;

        return (health >= 0);
    }

    // Update soil pH based on the chosen fertilizer
    public void Fertilize(Fertilizer f)
    {
        switch (f)
        {
            case Fertilizer.Acid:
                pH -= 0.1f;
                break;

            case Fertilizer.Alkali:
                pH += 0.1f;
                break;
        }
        Mathf.Clamp(pH, 0.0f, 14.0f);
    }

    // Increase the soil moisture
    void Water()
    {
        moisture += 0.1f;
        Mathf.Clamp(moisture, 0.0f, 1.0f);
    }

    // Talk to the plant
    void Talk()
    {
        // TODO: Make this show interesting dialogue?
        float chance = Random.Range(0, 100.0f);
        if (chance <= 10.0f)
        {
            happiness += (given_name != null) ? 2 : 1;
        }
        happiness = Mathf.Clamp(happiness, 0, 100);
    }

}

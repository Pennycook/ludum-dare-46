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
using UnityEngine.UI;

public class pHMonitor : MonoBehaviour
{
    public Plant plant;
    Image bar;

    // Color values for pH
    static Color[] colors =
    {
        new Color32(237, 27, 37, 255),
        new Color32(243, 100, 50, 255),
        new Color32(247, 143, 29, 255),
        new Color32(255, 195, 35, 255),
        new Color32(255, 242, 0, 255),
        new Color32(132, 195, 65, 255),
        new Color32(77, 183, 73, 255),
        new Color32(51, 169, 75, 255),
        new Color32(0, 184, 182, 255),
        new Color32(10, 184, 182, 255),
        new Color32(70, 144, 205, 255),
        new Color32(56, 83, 164, 255),
        new Color32(90, 81, 162, 255),
        new Color32(99, 69, 157, 255),
        new Color32(108, 32, 128, 255),
        new Color32(74, 23, 110, 255)
    };

    void Start()
    {
        bar = GetComponent<Image>();
    }

    void Update()
    {
        int pH = (int) plant.pH;
        bar.color = colors[pH];
    }
}

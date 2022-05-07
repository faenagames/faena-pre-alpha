Ok here’s what I need you to do now. Mira, 1. you go up to someone, 
then greet them using “Hola” “Buenos días” or both, 
“hola, buenos días”. Repite ‘Hola’. 
*   [hola] -> line_2
-> END

=== line_2 ===
# char: Sarelia
# audio: filename.wav
Repite “buenos días!”
*   [buenos días] -> line_3
-> END

=== line_3 ===
# char: Sarelia
# audio: filename.wav
Repite “hola, buenos días”
*   [hola, buenos días] -> line_4
-> END

=== line_4 ===
# char: Sarelia
# audio: filename.wav
ay muy bueno. perfecto! I knew you could do this. After you greet them, 
they will greet you back, then you respond with who you are and ask 
them what their name is, listo? ok. Repite: Me llamo Piyáa, 
¿cómo te llamas tú?
*   [me llamo pía cómo te llamas tú] -> line_5
-> END

=== line_5 ===
# char: Sarelia
# audio: filename.wav
Que lindo! That just means my name is Piyáa, what is your name? 
Then they will tell you their name, and you write it down in the 
cuaderno, and say “gracias!”. Repite, gracias!
*   [gracias] -> modeling
-> END

=== modeling ===
# char: Sarelia
# audio: filename.wav
# modeling
Ayy im so proud of you Piyáa, listo! Let’s run it through together 
just me and you ok? Remember 1. greet (saludar), then I’ll greet you, 
then 2. you introduce yourself and ask what my name is, then I’ll tell 
you 3. write it down on the paper and say gracias to me! then go move on
 to the next person. You start!
 *   [Hola buenos días] -> modeling_2
 -> END

 === modeling_2 ===
# char: Sarelia
# audio: filename.wav
# modeling
Muy buenos días. 
 *   [Me llamo Piyáa cómo te llamas] -> modeling_3
 -> END

  === modeling_3 ===
# char: Sarelia
# audio: filename.wav
# modeling
# await: journal_action
Hola Piyáa, me llamo Sarelia. 
 -> END

 === final ===
# char: Sarelia
# audio: filename.wav
# begin: quest_name
  nada, a tí. Perfecto!!! you did it!! Ok, estás listo, you’re ready. 
  ¡¡Bring me back todos los nombres!! 
-> END

 === npc_1 ===
# char: andreas
# audio: filename.wav
 hola.
 *   hola -> npc_1_met
 *   hola buenos días -> npc_1_met
 *   buenos días -> npc_1_met

  === npc_1_met ===
  -> END

   === npc_2 ===
# char: maya
# audio: filename.wav
 hola.
 *   hola -> npc_2_met
 *   hola buenos días -> npc_2_met
 *   buenos días -> npc_2_met

  === npc_2_met ===
  -> END

     === npc_3 ===
# char: gala
# audio: filename.wav
 hola.
 *   hola -> npc_3_met
 *   hola buenos días -> npc_3_met
 *   buenos días -> npc_3_met

  === npc_3_met ===
  -> END
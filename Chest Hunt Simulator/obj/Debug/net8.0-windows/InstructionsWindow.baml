   M S B A M L   `   `   `  ����  Chest Hunt Simulator-    'Chest_Hunt_Simulator.InstructionsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Instructions��5   	   $	��620��6   $	��620��6+   $	��620��6;   $	��640��6K   $	��640��6W   $	��640��6f    � Icon$ 	crayy.ico��6u    � 	Resources 5       �� 
TargetType   CustomButtonStyle �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value��%,  &	        �� 5   
   " ��6   .�5      ��  � �� �#007ACC6+   �� 5	       � ��
 �����6+   �� 5
       � ��$
 Bold"�6+   �� 5       � �� �#005B996,   �� 5       � ��$ 2q�60   �� 5       � ��$	 5,2q�6(   �� 5       � ��$ 40��6'   �� 5       � ��$	 120��6&   �� 5       � ��$ 4q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 5��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5      	 �@J�IsMouseOver$

 True��6=   . �5   "   ��  � �� �#005B996?   5      P� 5      	 � ��$

 True��6;   . �5   "   ��  � �� �#0040806?   5       5"      5$      5%      5&      .��5(      � $��10q�6   .+�5)   
   �� $
��Wrap=�6   $��14(�6(   $��
10,10,10,0q�66   �� 5*      $�How it Works:��6   $
��Bold"�6'   �� 5+      �� 5,      $2�,The game simulates Chest Hunt from the game ��6    �� 5-      $�Idle Slayer��6   $
��Bold"�6%    �� 5.      $'�!. Assumes you have activated the ��6    �� 5/      $�Saver Locator��6   $
��Bold"�6'    �� 50      $�, crafted both ��6    �� 51      $�Crystal Saver��6   $
��Bold"�6'    �� 52      $� and ��6    �� 53      $�Reinforced Crystal Saver��6   $
��Bold"�62    �� 54      $�, and unlocked ��6    �� 55      $ �Sucker Ninja, Ninja Gloves��6   $
��Bold"�64    �� 56      $�, and ��6    �� 57      $�An Ace Up My Sleeves��6   $
��Bold"�6.    �� 58      $@�:. Toggle visual mode to see mimics and x2 chest locations.��6   �� 59      �� 5;      $��1q�6   
���   �$��	0,10,0,10q�6=   $
��1000��6P    �� 5=      $�Stats:��6   $
��Bold"�6    �� 5>      �� 5?      $���Compare your stats to averages from 20,000,000 simulations. Enter your stats and see how you match up (calculations assume all Chest Hunt upgrades unlocked. Actual stats may vary due to the lack of real game data and user-specific upgrades. Treat these stats as estimates. Future updates may provide more accurate data).��6   �� 5@      �� 5B      $��1q�6   
���   �$��	0,10,0,10q�6=   $
��1000��6P    �� 5D      $�Odds of Winning:��6   $
��Bold"�6*   �� 5E      �� 5F      $���Calculated by running 20,000 simulations of the game every single time the game state changes. Provided purely as general information.��6   �� 5G      �� 5I      $��1q�6   
���   �$��	0,10,0,10q�6=   $
��1000��6P    �� 5K      $�Simulations:��6   $
��Bold"�6&   �� 5L      �� 5M      $c�]1. Enter number of simulations (suggested no more than 5,000,000 at a time to avoid crashes).��6   �� 5N      �� 5O      $�	2. Click ��6    �� 5P      $�Run Simulations��6   $
��Bold"�6)    �� 5Q      $�.��6   �� 5R      �� 5S      $x�r3. The strategy used: Opening chests until x2 chest, use it on the located saver chest, continue randomly picking.��6   �� 5T      �� 5U      $5�/4. Results show Perfect Chest Hunts and losses.��6   �� 5V      �� 5W      $G�A5. Assumes all Chest Hunt upgrades unlocked. Real stats may vary.��6   �� 5X      �� 5Y      �� 5Z      $�Enjoy the program!��6   5[      �� 5\   
   -   5        $��Close��5\      $	��100��6!   $��30��6-   $��Center=�69   $��Bottom=�6V   $��10q�6q   #��[  6�   5]      5^      
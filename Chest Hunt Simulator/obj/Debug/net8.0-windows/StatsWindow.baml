   M S B A M L   `   `   `  ����  Chest Hunt Simulator&     Chest_Hunt_Simulator.StatsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Enter Stats��5   	   $	��335��6   $	��335��6*   $	��335��6:   $	��240��6J   $	��240��6V   $	��240��6e   
������� � Icon$ 	crayy.ico��6�    � 	Resources 5       �� 
TargetType   CustomButtonStyle �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value  ImageButtonStyle��%k  &	        &	 "    �� 5   
   " ��6   .�5      ��  � �� �#007ACC6+   �� 5	       � ��
 �����6+   �� 5
       � ��$
 Bold"�6+   �� 5       � �� �#005B996,   �� 5       � ��$ 2q�60   �� 5       � ��$	 5,2q�6(   �� 5       � ��$ 40��6'   �� 5       � ��$	 120��6&   �� 5       � ��$ 4q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 5��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5      	 �@J�IsMouseOver$

 True��6=   . �5   "   ��  � �� �#005B996?   5      P� 5      	 � ��$

 True��6;   . �5   "   ��  � �� �#0040806?   5       5"      5$      5%      �� 5'   
   " ��6   .�5(      ��  � �� 6+   Z� �� 5)       � �� 6,   Z� �� 5*       � �� 5+      �� 5,      " ��6&   .R�5-      �� #��z��6!   #��z��5.   !   $��0q�5/   !   ._�50      �� $��Center=�6/   $��Center=�6L   51      52      54      55      56      .��58      � .+�59   
   �� $��10q�6   .+�5:      �� $��Enter played Chest Hunts:��6   $��0,0,0,10q�69   $
��Bold"�6K   $��14(�6]   �� 5;      -   5        $��PlayedGamesTextBox��5;      $	��200��60   $��0,0,0,10q�6<   $��26��6N    � ToolTip$6 0Enter the number of chest hunts you have played.��6Z    �� SelectionOpacity$ 3Q�6�   �� 5<      $��
Enter PCH:��6   $��0,0,0,10q�6*   $
��Bold"�6<   $��14(�6N   �� 5=      -   5        $��WinsTextBox��5=      $	��200��6)   $��0,0,0,20q�65   $��26��6G   $3 -Enter the number of chest hunts you have won.��6S   $	 -12Q�6�   �� 5>       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5?      �� -   5        $��Calculate Stats��5?      #��[  6V   $@ :Click to calculate your stats based on the entered values.��6�   �� 5@      #��[ 6    5A      _� 5B      .��5C      �� .+�5D   "   �� $
��Bold"�6,   $��14(�6>   $��0,0,0,5q�6L   Notice6e   �� 5E   "   $
��Wrap=�6,   $	��200��6@   ��Stats assume all Chest Hunt upgrades unlocked. Actual stats may vary due to the lack of real game data and user-specific upgrades. Treat these stats as estimates, not facts. Future updates may provide more accurate data.5G   #   5H      5I      ��5K      �� 5L      $��images/info.png��6    $��20��69   $��20��6D   5N      5O      �� 5P      -   5        $��StatsResultTextBlock��5P      $��
10,10,10,0q�64    �� TextAlignment$ Center=�6H   $
��Bold"�6_   $��14(�6q   5Q      5R      5S      
   M S B A M L   `   `   `  ����^  ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  5      [ WSystem.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5      tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  5       NeginProject!   NeginProject.Results.HouseS   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      ]wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration    5      Mwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms    5      \myOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration    5      7my1-http://schemas.microsoft.com/wpf/2008/toolkit  5      -   5        $	��680��5   <   $��Tahoma)�5      $��20(�6   $
��1197��6'     � WindowState$  	Maximized=�6I   
����ح� � Title$C =فرم نتيجه منزل يا مجموعه استيجاري��5   ?    � 	Resources 5	         MediaButtonTheme �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources  Key �� TargetProperty	 �� 
TargetName
 O� KeyTime O� Value �Name J� RenderTransformOrigin J� SnapsToDevicePixels �� Triggers P� Property P� Value N� ExitActions ��Name  Storyboard_Copy1 N� EnterActions  Storyboard1��%F  &	        7  7  �� 5
   
   " ��6)   .�5      ��  � �� 5      �� 5      " ��6&    5      ���� 5      Storyboard1 .��5   "   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6@   $
	 grid��6�   .\�5   &   �� $
 0:0:0.5��6;   $
 1.25Q�6M   5   #   U� 5   "   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6@   $
	 grid��6�   .\�5   &   �� $
 0:0:0.5��6;   $
 1.25Q�6M   5   #   5      �� 5      Storyboard_Copy1 .��5   "   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6@   $
	 grid��6�   .\�5   &   �� $
 0:0:0.5��6;   $ 1Q�6M   5   #   U� 5   "   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6@   $
	 grid��6�   .\�5   &   �� $
 0:0:0.5��6;   $ 1Q�6M   5   #   5      5      .R�5       � $
 grid��6   $ 0.5,0.5&�6-   z�5!      V� 5"   "   .~�5#   &   �� �� 5$   &   �� 5%   &   T� 5&   &   5'   #   .+�5)      �� $.��(/NeginProject;component/Images/image.png��6$   �� 5*      #��z��6/   ��. # z 6�   #��z��6�   $�� ��6  5+       5,      P� 5-       �@J�	IsFocused . 6;   P� 5.       �@��IsDefaulted . 6=   P� 5/       �@J�IsMouseOver .  50   "   �� 51   &   $&  Storyboard_Copy1_BeginStoryboard��66   8��  6`    53   "   �� 54   &   8�� 66   56      P� 57       � �� . 6;   P� 58       � {� .  6;   5:      5<      5=      5>      .��5?      �� -   5        $��mainSP��5?      .+�5@   
   � .+�5A      �� $��Stretch=�6   $��Stretch=�66   
���   �$��1��6a   5C      � 5D      -   5        $��Caption��5D   7   $��80��6   $	��Top=�6    � ColumnDefinitions 5F      �� 5G      $
��215* �6'   �� 5H      $
��785* �6'   .+�5K      �� -   5        $��Lbl_DatePrompt��5L   8   $��تاريخ :��5K      $��Tahoma)�6*   $��RightToLeft=�5L      $
��Left=�5M      $	��Top=�5N      $��	191,0,0,0q�64   6I   �� 5O      -   5        $��date_Lbl��5P   8   $
��Date��5O      $��Tahoma)�6'   $��LeftToRight=�5P      $
��Left=�5Q      $	��Top=�5R      $	��131��64   6B   �� 5S      -   5        $��Lbl_IDPrompt��5T   <   $��شماره :��5S      $��Tahoma)�6*   $��RightToLeft=�5T       $
��Left=�5U       $��Bottom=�5V       $��	175,0,0,0q�6;   6P   �� 5W      -   5        $��ID_Lbl��5X       $��ID��5W      $��Tahoma)�6%   $
��Left=�5Y       $��Bottom=�5Z       $	��131��6;   6I   �� 5[      -   5        $��Lbl_HeaderText��5\   <   $C��=فرم نتيجه منزل يا مجموعه استيجاري��5[      $��1��6D   $��Tahoma)�6T   $��RightToLeft=�5\       $��25(�6R   $��199,0,324,20q�6`   ���	#FF3956D36�   �� 5]      -	   5        $��	removeLbl��5]   �   $��15(�6   $��RightToLeft=�6&   $��Tahoma)�6B   
���  ��$��26.633,0,229.097,0q�6g   $y�Hidden=�6�   $��Bottom=�6�   $��1��6�   $��28.107��6�   .��6�   removelabel6�   �� 5^      -
   5        $��changeCombo��5^   O   $��Right=�6   $��0,21,138.34,29q�67    �� SelectedIndex$ 0��6b   $y�Hidden=�6t   $��84.285��6�   $��1��6�   .@�5_      �� .��6#   ویرایش6+   �� 5`      .��6#   حذف6(   �� 5a      .��6#   انصراف6+   5b      �� 5c      -   5        $��Print_Button��5c   m   $��48��64   $
��Left=�6@   $��75,8,0,0q�6[   $	��Top=�6�   $��57��6�   $��1��6�   .��5d      �� $��46��6   $0��*/NeginProject;component/Images/printer.png��6(   5e      �� 5f      -   5        $��
editButton��5f   {   $��RightToLeft=�6   $��Tahoma)�65   $��Right=�6I   $��0,21,4.34,29q�6e   $y�Hidden=�6�   $��127.34��6�   $��1��6�   .��6�   اعمال ویرایش6�   �� 5g      -   5        $��MediaButton��5g   f   $��Button��6   $��39��6*   $��Right=�66   $��
0,10,245,0q�6R   #���   6y   $	��Top=�6�   $��54��6�   $��1��6�   6�   5h      5i      � 5j   
   -   5        $��
FirstOrder��5j   (   $	��Top=�6    � RowDefinitions 5l      �� 5m      $	��36* �6    �� 5n      $	��58* �6    �� 5o      $	��56* �6    .+�5q      �� $��Stretch=�6   $��6��66   $��4��6J   $��Stretch=�6[   
���   �$��1��6�   6�   � 5r      $��0��6    5s      �� 5t      $��954.637* �6'   �� 5u      $��45.363* �6'   .+�5w      �� -   5        $��Lbl_Address��5x   =   $��
آدرس :��5w      $��RightToLeft=�5x   !   $��Right=�5y   !   $��2��6=   $��74��6Q   6^   �� 5z      -   5        $��textBox1��5{       �� 
IsReadOnly . $��RightToLeft=�5z   -   $��	51,0,26,0q�5{   *   .��6=   5}      5~      � 5      $��1��6    5�      �� 5�      $
��185* �6'   �� 5�      $
��206* �6'   �� 5�      $
��163* �6'   �� 5�      $
��171* �6'   �� 5�      $
��185* �6'   �� 5�      $
��207* �6'   .+�5�      �� -   5        $��Lbl_Area��5�   <   $��مساحت زمين :��5�      $��5��6/   $��RightToLeft=�5�       $��Right=�5�       $��Center=�5�       6>   �� 5�      -   5        $��textBox2��5�       . $��5��5�   -   $��RightToLeft=�6=    �� TextAlignment$ Center=�5�   *   $��	0,2,133,2q�6A   $��Right=�6T   $��84��6p   .��6{   5�      �� 5�      -   5        $��
Lbl_Width1��5�   <   $��عرض زمين :��5�      $��4��6-   $��RightToLeft=�5�       $��Right=�5�       $��Center=�5�       6>   �� 5�      -   5        $��textBox3��5�       . $��3��5�   -   $��RightToLeft=�6=   $ Center=�5�   *   $��	0,2,123,2q�6A   $��Right=�6T   $��90��6p   $��2��6{   .��6�   5�      �� 5�      -   5        $��
Lbl_Width2��5�   <   $��بر زمين :��5�      $��3��6,   $��RightToLeft=�5�       $��Right=�5�       $��Center=�5�       $��0,0,26,0q�6;   6O   �� 5�      -   5        $��textBox4��5�       . $��2��5�   -   $��RightToLeft=�6=   $ Center=�5�   *   $��	0,2,106,2q�6A   $��Right=�6T   $��99��6p   $��2��6{   .��6�   5�      �� 5�      -   5        $��Lbl_ZirArea��5�   <   $��زير بنا :��5�      $��2��6,   $��RightToLeft=�5�       $��Right=�5�       $��Center=�5�       $��0,0,26,0q�6;   6O   �� 5�      -   5        $��textBox5��5�       . $��1��5�   -   $��RightToLeft=�6=   $ Center=�5�   *   $��0,2,92,2q�6A   $��Right=�6S   $��98��6o   $��2��6z   .��6�   5�      �� 5�      -   5        $��Lbl_GoodArea��5�   <   $��متراژ مفيد :��5�      $��1��6/   $��RightToLeft=�5�       $��Right=�5�       $��Center=�5�       $��0,0,26,0q�6;   6O   �� 5�      -   5        $��textBox6��5�       . $��RightToLeft=�5�   -   $ Center=�5�   *   $��	0,2,159,2q�6A   $��2��6T   $��Right=�6h   $��91��6�   .��6�   5�      5�      � 5�      $��2��6    5�      �� 5�      $
��185* �6'   �� 5�      $
��206* �6'   �� 5�      $
��163* �6'   �� 5�      $
��171* �6'   �� 5�      $
��185* �6'   �� 5�      $
��207* �6'   .+�5�      �� -   5        $��
Lbl_Floors��5�   <   $��تعداد طبقات :��5�      $��5��60   $��RightToLeft=�5�       $��42.967,0,0,0q�6N   6f   �� 5�      -   5        $��textBox8��5�       . $��5��5�   -   $��RightToLeft=�6=   $ Center=�5�   *   $��	0,2,133,2q�6A   $��Right=�6T   $��84��6p   .��6{   5�      �� 5�      -   5        $��	Lbl_Flats��5�   <   $��تعداد واحدها :��5�      $��4��61   $��RightToLeft=�5�       $��Right=�6M   $��136.422��6i   6{   �� 5�      -   5        $��textBox9��5�       . $��3��5�   -   $��RightToLeft=�6=   $ Center=�5�   *   $��	0,2,123,2q�6A   $��Right=�6T   $��90��6p   $��2��6{   .��6�   5�      �� 5�      -   5        $��	Lbl_Mabar��5�   <   $��
معبر :��5�      $��3��6)   $��RightToLeft=�5�       $��Right=�5�       $��Center=�5�       $��0,0,26,0q�6;   6O   �� 5�      -    5        $��	textBox10��5�       . $��2��5�   -   $��RightToLeft=�6=   $��	0,2,106,2q�5�   +   $��Right=�6>   $��99��6Z   $��2��6e   .��6y   5�      �� 5�      -!   5        $��Lbl_nama��5�   <   $��نما :��5�      $��2��6(   $��RightToLeft=�5�       $��Right=�5�       $��Center=�5�       $��0,0,26,0q�6;   6O   �� 5�      -"   5        $��	textBox11��5�       . $��1��5�   -   $��RightToLeft=�6=   $��0,2,92,2q�5�   +   $��Right=�6=   $��98��6Y   $��2��6d   .��6x   5�      �� 5�      -#   5        $��textBox7��5�   I    . $��RightToLeft=�6-   $��
0,-1,159,5q�6Y   $��2��6m   $��Right=�6�   $��91��6�   6�   �� 5�      -$   5        $��Lbl_Yearold��5�   J   $��مدت ساخت :��6   $��RightToLeft=�6.   $��	0,-3,27,3q�6]   $��1��6p   $��Right=�6�   $��133.075��6�   6�   5�      5�      � 5�   
   -%   5        $��	_2ndOrder��5�   '   $	��Top=�6    5�      �� 5�      $
��339* �6#   �� 5�      $��152.44* �6#   �� 5�      $
��163* �6#   �� 5�      $
��356* �6#   �� 5�      $
��106* �6#   .+�5�      �� $��5��6   
���   �$��1��6;   5�      �� 5�      -&   5        $��Lbl_tasisat��5�   E   $��تاسيسات :��6   $��RightToLeft=�6)   $��0,2,0,-2q�6X   $��3��6j   $
��Left=�6z   $��105.405��6�   6�   �� 5�      -'   5        $��	textBox12��5�   E    . $��RightToLeft=�6)   $��0,3,14,1q�6V   $��2��6h   $��Right=�6|   $��314.325��6�   $��1��6�   6�   �� 5�      -(   5        $��	Lbl_Sanad��5�   C   $��RightToLeft=�6   $��0,1,0,-1q�61   $��3��6T   $��2��6d   $��Right=�6x   $��133.27��6�   .��6�   وضعيت تخليه :6�   �� 5�      -)   5        $��	textBox13��5�   I   $��RightToLeft=�6   $��0,2,21.646,2q�63   $��3��6Z   $��Right=�6j   $	��239��6�   5�      � 5�   
   -*   5        $��	_3rdOrder��5�   (   $	��Top=�6    5�      �� 5�      $
��288* �6#   �� 5�      $
��712* �6#   .+�5�      � $��0��6    5�      �� 5�      $	��40* �6$   �� 5�      $
��220* �6$    5�      �� 5�      $
��146* �6'   �� 5�      $
��142* �6'   .+�5�      �� 
���   �$��1��6+   $��2��6?   $��2��6S   5�      �� 5�      -+   5        $��Lbl_Mogheiat��5�   8   $��موقعيت��5�      $��RightToLeft=�5�      $��Center=�5�      $��1��67   $��0��6G   $��Center=�6T   6t   �� 5�      -,   5        $��Lbl_Emkanat��5�   8   $��امکانات��5�      $��RightToLeft=�5�      $��Center=�6e   $��0��6�   $��0��6�   $��Center=�6�   6�   �� 5      $��1��6   $��1��6-   $��Center=�6:   .+�5     �� --   5        $��	checkBox1��5  /   $��
شمالي��6   $��RightToLeft=�6A   6_   �� 5     -.   5        $��	checkBox2��5  0   $��
جنوبي��6   $��RightToLeft=�6A   6_   �� 5     -/   5        $��	checkBox3��5  /   $��شرقي��6   $��RightToLeft=�6@   6^   �� 5     -0   5        $��	checkBox4��5  /   $��غربي��6   $��RightToLeft=�6@   6^   �� 5     -1   5        $��	checkBox5��5  1   $��بن بست��6   $��RightToLeft=�6B   6`   �� 5     -2   5        $��	checkBox6��5  /   $��کوچه��6   $��RightToLeft=�6@   6^   �� 5     -3   5        $��	checkBox7��5  B   $��18(�6   $��بر خيابان��6-   $��RightToLeft=�6S   6q   5     �� 5	     $��0��6   $��1��6-   $��Center=�6:   .+�5
     �� -4   5        $��	checkBox8��5
  .   $��تلفن��6   $��RightToLeft=�6@   6^   �� 5     -5   5        $��	checkBox9��5  2   $��پارکينگ��6   $��RightToLeft=�6C   6a   �� 5     -6   5        $��
checkBox10��5  1   $��انباري��6   $��RightToLeft=�6C   6a   �� 5     -7   5        $��
checkBox11��5  2   $��آسانسور��6   $��RightToLeft=�6D   6b   �� 5     -8   5        $��
checkBox12��5  0   $��
استخر��6   $��RightToLeft=�6B   6`   �� 5     -9   5        $��
checkBox13��5  /   $��سونا��6   $��RightToLeft=�6A   6_   �� 5     -:   5        $��
checkBox14��5  >   $��18(�6   $��
جکوزي��6-   $��RightToLeft=�6P   6n   5     5     � 5     $��1��6    5     �� 5     $
��180* �6$   �� 5     $��19.324* �6$   �� 5     $��17.911* �6$   �� 5     $��42.84* �6$   .+�5     �� $��Stretch=�6   $��Stretch=�6:   $��4��6V   
���   �$��1��5  +   5     7   1System.Windows.Forms.Integration.WindowsFormsHost  5     -;   5        $��WinFormHost��5  Q      FontSize$ 15Q�6'   $��RightToLeft=�65   $��0,0,0,4q�6d   $��3��6u      Child. 5      '  !System.Windows.Forms.DataGridView     AutoSize .    AllowUserToAddRows .    AllowUserToDeleteRows .    AllowUserToOrderColumns .     AllowUserToResizeColumns  . !   AllowUserToResizeRows! . -<   5        gridView��5   �   5!     � 5"     $��1��6   $��0,0,0,0.012q�6$   $��2��69   $��Bottom=�6J    5#     �� 5$     $
��436* �6+   �� 5%     $
��276* �6+   5'     � 5(     $��3��6   $��0,1.853,0,0q�6$   $	��Top=�69    5)     �� 5*     $
��436* �6+   �� 5+     $
��276* �6+   5-     � 5.     $��3��6   $��0,0,0,1q�6$   $��Bottom=�65    5/     �� 50     $	��42* �6(   �� 51     $	��38* �6(    53     �� 54     $
��436* �6+   �� 55     $
��276* �6+   .+�57     �� 
���   �$��2��6/   $��2��6C   6R   �� 58     -=   5        $��Lbl_Explain3��59  <   $��شرايط تبديل :��58     $��1��64   $��RightToLeft=�59      $��Right=�5:      $��138.34��6<   $��0,-2,0,4.28q�6K   6b   �� 5;     ->   5        $��	textBox18��5;  M    . $��RightToLeft=�61   $��0,2,144,5.28q�6^   $��2��6t   $��Right=�6�   $	��424��6�   .��6�   5<     �� 5=     -?   5        $��	Lbl_Malek��5=  Z   $��RightToLeft=�6   $��1��69   $��0,0,0,5q�6I   $��Right=�6k   $��Bottom=�6�   $��64.407��6�   $��2��6�   .��6�   
مالک :6�   �� 5>     -@   5        $��	textBox14��5>  `   $��RightToLeft=�6   $��1��6;   $��0,2.86,71,5q�6K   $��1��6q   $��Right=�6~   $	��230��6�   �� 5?     -A   5        $��Lbl_TelHamahangi��5?  J   $��RightToLeft=�6   $��0,0,0,5q�69   $��Bottom=�6b   $��Right=�6}   $	��193��6�   $��2��6�   .��6�   " تلفن هاي هماهنگي :6�   �� 5@     -B   5        $��	textBox15��5@  Q   $��RightToLeft=�6   $��0,2.86,199,5q�6;   $��1��6b   $��Right=�6o   $	��304��6�   5A     5B     5C     � 5D  
   -C   5        $��	_4thOrder��5D  '   $	��Top=�6    5E     �� 5F     $
��279* �6#   �� 5G     $	��82* �6#   �� 5H     $
��169* �6#   �� 5I     $
��160* �6#   �� 5J     $��316.382* �6#   �� 5K     $
��110* �6#   .+�5M     �� 
���   �$��1��6'   $��6��6;   5O     �� 5P     -D   5        $��Lbl_Price_harmetr_zamin��5Q  8   $��ميزان رهن :��5P     $��RightToLeft=�5Q     $��Center=�5R     $��5��67   $��Right=�6G   6f   �� 5S     -E   5        $��	textBox16��5S  C   $��LeftToRight=�6   $��4��63   $��2��6x   $��
0,12,110,8q�6�   $��Right=�6�   $	��300��6�   .��6�   5T     �� 5U     -F   5        $��Lbl_Price_harmetr_sakht��5V  8   $��ميزان اجاره :��5U     $��RightToLeft=�5V     $��3��6W   $��0,7,0,9q�6g   6z   �� 5W     -G   5        $��	textBox17��5W  C   $��LeftToRight=�6   $��1��63   $��0,10,122.87,9q�6T   $��3��6�   $��Right=�6�   $	��309��6�   .��6�   5X     5Y     � 5Z  
   -H   5        $��	_5thOrder��5Z  '   $	��Top=�6    5[     �� 5\     $��281.664* �6#   �� 5]     $��696.336* �6#   .+�5_     �� 
���   �$��1��6'   $��2��6;   5a     �� 5b     -I   5        $��txt_Moarefino��5b  )    . $��RightToLeft=�6>   $��0,40.362,119,40.362q�6Z   $��Right=�6w   $	��197��6�   .��6�   5d     �� 5e     $��Center=�6   $��Right=�6/   $��RightToLeft=�6K   $��نوع معرفي :��5f     5h     �� 5i     -J   5        $��richTextBox1��5i  t   $" �� HorizontalScrollBarVisibility$
" Auto=�6   "# �� VerticalScrollBarVisibility$
# Auto=�6?    . $��RightToLeft=�6�   $	��728��6�   $��1��6�   $��0,14,97.648,10q�6�   $��Right=�6�   6�   �� 5j     $	��Top=�6   $��Right=�6,   $��1��6H   $��RightToLeft=�6X   $��توضيحات :��5k     $��0,15,0,0q�6)   $��92.91��6;   5m     5n     � 5o  
   $��Bottom=�6    5p     �� 5q     $
��508* �6#   �� 5r     $
��492* �6#   .+�5t     �� -K   5        $��next_button��5t  -   $��0,0,154.848,29q�6   $��10��6@   $��1��6N   $��Right=�6x   $	��145��6�   $��33��6�   $��Bottom=�6�   .��6�   
بعدي5v     �� 5w     -L   5        $��before_button��5w  E   $��Right=�6   $��
0,0,360,29q�61   $��11��6Z   $	��110��6h   $��1��6t   $��33��6�   $��Bottom=�6�   .��6�   
قبلي5y     �� 5z     -M   5        $��back_button��5z  I   $��Right=�6   $��0,0,110.848,29q�61   $��11��6\   $	��137��6j   $��33��6�   $��Bottom=�6�   .��6�   بازگشت5|     �� 5}     -N   5        $��next_img��5}  �   $��1��6   $��Right=�6$   $��
0,0,149,26q�6@   $0��*/NeginProject;component/Images/forward.png��6T   $��51.411��6�   $��51��6�   $��Bottom=�6�   6�   �� 5~     -O   5        $��back_img��5~  �   $��
0,0,207,31q�6   $/��)/NeginProject;component/Images/return.png��6(   $��46��6[   $��Bottom=�6g   $��Right=�6�   $��52��6�   6�   �� 5     -P   5        $��
before_img��5  �   $��Right=�6   $��
0,0,425,25q�60   $-��'/NeginProject;component/Images/back.png��6D   $��51.411��6u   $��1��6�   $��51��6�   $��Bottom=�6�   6�   5�     5�     5�     
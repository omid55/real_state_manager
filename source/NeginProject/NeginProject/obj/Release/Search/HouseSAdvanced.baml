   M S B A M L   `   `   `  ���� G  CNeginProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:NeginProjectNeginProject  (    "NeginProject.Search.HouseSAdvanced   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    *localclr-namespace:NeginProject    7my1-http://schemas.microsoft.com/wpf/2008/toolkit  -   $	��726��$
��1000��  � WindowState$  	Maximized=�
����ح� � Title$T Nفرم جستجوی پیشرفته منزل يا مجموعه استيجاري��.���� .+�� .+��� $��Stretch=�$��Stretch=�
���   �$��1��� -   $��Caption��$��60��$	��Top=� � ColumnDefinitions �� $
��215* ��� $
��785* �.+��� -   $��Lbl_DatePrompt��$��تاريخ :��$��Tahoma)�$��RightToLeft=�$��Right=�$��0,3,0,27q�$��38.417���� -   $��Lbl_IDPrompt��$��شماره :��$��Tahoma)�$��RightToLeft=�$��Right=�$
��47.2��$��30��$��Bottom=��� -   $��Lbl_HeaderText��$T��Nفرم جستجوی پیشرفته منزل يا مجموعه استيجاري��$��1��$��Tahoma)�$��RightToLeft=�$��20(�$��Center=�$��	0 0 190 0q����	#FF3956D3$��Center=�"  NeginProject.MyMaskedTextBox  -     Name$ 
MaskedDate��   StayInFocusUntilValid .     Mask$ 
0000/00/00��   IgnoreSpace . $��	78,4,65,0q�$��23��$	��Top=��� -   $��ID_Txt��$��RightToLeft=�$��Tahoma)�$
��19.5��$��77.27,0,65.73,6q� �� TextAlignment$ Center=�$��Bottom=�� -   $��
FirstOrder��$	��120��$	��Top=� � RowDefinitions �� $	��36* ��� $	��58* ��� $	��56* �.+��� $��Stretch=�$��6��$��4��$��Stretch=�
���   �$��1��� $��0�� �� $��954.637* ��� $��45.363* �.+��� -	   $��Lbl_Address��$��
آدرس :��$��1��$��Tahoma)�$��RightToLeft=�$��Right=�$��Center=��� -
   $��textBox1��$��Tahoma)�$��0��$��RightToLeft=�$	��768��$��Stretch=�$��20��$��Right=�.��� $��1�� �� $
��186* ��� $
��164* ��� $
��146* ��� $
��153* ��� $
��166* ��� $
��185* �.+��� -   $��Lbl_Area��$��مساحت زمين :��$��5��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -   $��textBox2��$��Tahoma)�$��5��$��RightToLeft=�$
��Left=�$��90��$��Center=�$ Center=�.���� -   $��
Lbl_Width1��$��عرض زمين :��$��4��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -   $��textBox3��$��Tahoma)�$��4��$��RightToLeft=�$
��Left=�$��90��$��Center=�$ Center=�.���� -   $��
Lbl_Width2��$��بر زمين :��$��3��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -   $��textBox4��$��Tahoma)�$��3��$��RightToLeft=�$
��Left=�$��90��$��Center=�$ Center=�.���� -   $��Lbl_ZirArea��$��زير بنا :��$��2��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -   $��textBox5��$��Tahoma)�$��2��$��RightToLeft=�$
��Left=�$��90��$��Center=�$ Center=�.���� -   $��Lbl_GoodArea��$��متراژ مفيد :��$��1��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -   $��textBox6��$��Tahoma)�$��1��$��RightToLeft=�$
��Left=�$��90��$��Center=�$ Center=�.���� -   $��Lbl_Yearold��$��مدت ساخت :��$��0��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -   $��textBox7��$��Tahoma)�$��0��$��RightToLeft=�$��10 0 0 0q�$
��Left=�$��90��$��Center=�.��� $��2�� �� $
��186* ��� $
��164* ��� $
��146* ��� $
��153* ��� $
��166* ��� $
��185* �.+��� -   $��
Lbl_Floors��$��تعداد طبقات :��$��5��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -   $��textBox8��$��Tahoma)�$��5��$��RightToLeft=�$
��Left=�$��90��$��Center=�$ Center=�.���� -   $��	Lbl_Flats��$��تعداد واحدها :��$��4��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -   $��textBox9��$��Tahoma)�$��4��$��RightToLeft=�$
��Left=�$��90��$��Center=�$ Center=�.���� -   $��	Lbl_Mabar��$��
معبر :��$��3��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -   $��	textBox10��$��Tahoma)�$��3��$��RightToLeft=�$
��Left=�$��90��$��Center=�$ Center=�.���� -   $��Lbl_nama��$��نما :��$��2��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -   $��	textBox11��$��Tahoma)�$��2��$��RightToLeft=�$
��Left=�$��90��$��Center=�.���� -   $��Lbl_tasisat��$��تاسيسات :��$��1��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -    $��	textBox12��$��Tahoma)�$��1��$��RightToLeft=�$
��Left=�$��90��$��Center=�.���� -!   $��	Lbl_Sanad��$��وضعيت تخليه :��$��0��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -"   $��	textBox13��$��Tahoma)�$��0��$��RightToLeft=�$��10 0 0 0q�$
��Left=�$��90��$��Center=�.��� -#   $��	_2ndOrder��$��40��$	��Top=� �� $
��440* ��� $
��146* ��� $
��319* ��� $	��95* �.+��� $��Stretch=�$��4��$��Stretch=�
���   �$��1���� -$   $��	Lbl_Malek��$��
مالک :��$��3��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -%   $��	textBox14��$��Tahoma)�$��2��$��RightToLeft=�$��Right=�$	��190��$��Center=�.���� -&   $��Lbl_TelHamahangi��$&�� تلفن هاي هماهنگي :��$��1��$��Tahoma)�$��RightToLeft=�$��Right=�$��30��$��Center=��� -'   $��	textBox15��$��Tahoma)�$��0��$��RightToLeft=�$��Right=�$	��190��$��Center=�.��� -(   $��	_3rdOrder��$	��260��$	��Top=� �� $
��288* ��� $
��712* �.+�� $��0�� �� $	��40* ��� $
��220* � �� $
��146* ��� $
��142* �.+��� 
���   �$��1��$��2��$��2���� -)   $��Lbl_Mogheiat��$��موقعيت��$��Tahoma)�$��RightToLeft=�$��30��$��Center=�$��1��$��0��$��Center=��� -*   $��Lbl_Emkanat��$��امکانات��$��Tahoma)�$��RightToLeft=�$��30��$��Center=�$��0��$��0��$��Center=��� $��1��$��1��$��Center=�.+��� -+   $��	checkBox1��$��
شمالي��$��Tahoma)�$��RightToLeft=��� -,   $��	checkBox2��$��
جنوبي��$��Tahoma)�$��RightToLeft=��� --   $��	checkBox3��$��شرقي��$��Tahoma)�$��RightToLeft=��� -.   $��	checkBox4��$��غربي��$��Tahoma)�$��RightToLeft=��� -/   $��	checkBox5��$��بن بست��$��Tahoma)�$��RightToLeft=��� -0   $��	checkBox6��$��کوچه��$��Tahoma)�$��RightToLeft=��� -1   $��	checkBox7��$��بر خيابان��$��Tahoma)�$��RightToLeft=��� $��0��$��1��$��Center=�.+��� -2   $��	checkBox8��$��تلفن��$��Tahoma)�$��RightToLeft=��� -3   $��	checkBox9��$��پارکينگ��$��Tahoma)�$��RightToLeft=��� -4   $��
checkBox10��$��انباري��$��Tahoma)�$��RightToLeft=��� -5   $��
checkBox11��$��آسانسور��$��Tahoma)�$��RightToLeft=��� -6   $��
checkBox12��$��
استخر��$��Tahoma)�$��RightToLeft=��� -7   $��
checkBox13��$��سونا��$��Tahoma)�$��RightToLeft=��� -8   $��
checkBox14��$��
جکوزي��$��Tahoma)�$��RightToLeft=�� $��1�� �� $
��180* ��� $��19.324* ��� $��17.911* ��� $��42.84* �.+��� $��Stretch=�$��Stretch=�$��4��
���   �$��1��� $��1��$��0,0,0,0.012q�$��2��$��17.922��$��Bottom=� �� $
��436* ��� $
��276* �� $��3��$��0,1.853,0,0q�$��17.988��$	��Top=� �� $
��436* ��� $
��276* �� $��3��$��0,0,0,1q�$��19.992��$��Bottom=� �� $
��436* ��� $
��276* �.+��� -9   $��Lbl_Explain3��$��شرايط تبديل :��$��1��$��Tahoma)�$��RightToLeft=�$��Right=�$��89.653��$��	0,-10,0,0q��� -:   $��	textBox18��$��Tahoma)�$��RightToLeft=�$��206.408,-5,0,5q�.��� -;   $��	_4thOrder��$��40��$	��Top=� �� $
��250* ��� $��73.637* ��� $
��151* ��� $��143.363* ��� $��204.547* ��� $��177.453* �.+��� 
���   �$��1��$��6���� -<   $��Lbl_Price_harmetr_zamin��$��ميزان رهن :��$��Tahoma)�$��RightToLeft=�$��30��$��Center=�$��5��$��Right=��� -=   $��	textBox16��$��Tahoma)�$��LeftToRight=�$��Right=�$��Center=�$��4��$	��120��.���� ->   $��Lbl_Price_harmetr_sakht��$��ميزان اجاره :��$��Tahoma)�$��RightToLeft=�$��30��$��Center=�$��3���� -?   $��	textBox17��$��Tahoma)�$��LeftToRight=�$��2��$��26.363,9.02,0,10.361q�.��� -@   $��	_5thOrder��$	��100��$	��Top=� �� $
��216* ��� $
��784* �.+��� 
���   �$��1��$��2���� -A   $��txt_Moarefino��$��Tahoma)�$��RightToLeft=�$��6,40.362,81.248,40.362q�.���� $��Center=�$��Right=�$��RightToLeft=�$��نوع معرفي :��$��Tahoma)��� $��Bottom=�$��Center=�$��RightToLeft=�$��امضاء :��$��Tahoma)��� -B   $��richTextBox1��$��RightToLeft=�$��Tahoma)�$��601.842��$��1��$��76��$��72,14,92.91,10q��� $��Center=�$��Right=�$��1��$��RightToLeft=�$��توضيحات :��$��Tahoma)�� $��Bottom=�$��81�� �� $
��508* ��� $
��492* �.+��� -C   $��search_button��$��Tahoma)�$��
19,19,0,30q�$
��Left=�$	��138��$��1��.��جستجو کن�� -D   $��back_button��$��Tahoma)�$��
0,19,22,30q�$��Right=�$	��115��.��بازگشت�� -E   $��Show3D_checkBox��$��215,27,126,36q�$��1��.��(&نمایش به صورت سه بعدی�� $��Right=�$��	0,5,95,30q�$/��)/NeginProject;component/Images/return.png��$��46���� $
��Left=�$��	19,6,0,31q�$/��)/NeginProject;component/Images/search.png��$
��45.2��$��1��
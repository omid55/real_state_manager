   M S B A M L   `   `   `  ����P  LDockingLibrary, Version=0.1.3731.30366, Culture=neutral, PublicKeyToken=nullG4clr-namespace:DockingLibrary;assembly=DockingLibraryDockingLibrary  5   	    NeginProject    NeginProject.MyMediaPlayer   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   Ecustom4clr-namespace:DockingLibrary;assembly=DockingLibrary    5   	   $��Tahoma)�6M   $   DockingLibrary.DockableContent    Title$  پخش موسیقی��5   	   $	��183��6   $	��548��6)   .��5      � .+�5   
   r� -   5         r�Name$ mediaPlayer��5      $��0��5       r� LoadedBehavior$ Manual=�6    r� UnloadedBehavior$ Close=�63   $��80��6n   $��17,0,470,15q�6}   $��23��6�   $��Bottom=�6�    r� Volume 5   ,   �� *Value+ �� ElementName$ 	VolSlider��5   �   �� 5	   
   -   5         ��Name$ playBtn��5	      $��اجرای موسیقی��6"   $��
230,0,0,11q�69   
���   �$
��Left=�6s   $
��Bold"�6�    � ToolTip$
 Play��6�   $��97��6�   $��27��6�   $��Bottom=�6�   �� 5
   
   -   5        $��توقف��5
      
���   �$
��Bold"�6F   $��	67,0,0,11q�6X   $
��Left=�6k   $��54��6�   $��28��6�   $��Bottom=�6�   �� 5   
   -   5        $��نگه داشتن��5      
���   �$
��Bold"�6L   $ Pause��6^   $��
136,0,0,11q�6n   $��27��6�   $��Bottom=�6�   $
��Left=�6�   $��75��6�   �� 5   
   -   5         ��Name$ 	VolSlider��5      $��	0,0,12,56q�6$   $��Bottom=�67   $��18��6R   	 � Maximum$	 1Q�6^   
 �� TickFrequency$	
 0.1Q�6j    � Value$ 1Q�6~   $��Right=�6�   $	��150��6�   �� 5   
   -   5        $ PositionSlider��5      $��
87,0,12,83q�6\   $��Bottom=�6p   $��19��6�   $
 1Q�6�   �� 5   
   -   5        $
��Bold"�5      $��انتخاب فایل��6#   
���   �$��
346,0,0,10q�6e   $ 
Chose File��6y   $��29��6�   $��Bottom=�6�   $
��Left=�6�   $	��128��6�   �� 5   
   -   5         ��Name$ 
nowPlaying��5      $��27,0,278,44q�6$   $
��Bold"�69   $��31��6K   $��Bottom=�6W   �� 5   
   -	   5        $��label2��5   V   $��درجه صدا : ��6   $��Right=�6&   $��
0,0,160,44q�6B   $��66��6d   $��33��6o   $��Bottom=�6{   �� 5   
   -
   5        $��label3��5   a   $��خط موسیقی :  ��6   $��32��6(   $
��Left=�64   $��5,0,0,74q�6O   $��Bottom=�6o   $��87��6�   �� 5   
   -   5        $��label1��5   �   $��Center=�6   $��Center=�6+   $��20(�6H   $��پخش موسیقی��6V   $��37��6k   $��215,0,174,107q�6w   6�   5      5      
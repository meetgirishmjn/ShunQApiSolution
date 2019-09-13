import { Component, OnInit, OnDestroy } from '@angular/core';
import { AppContext } from './services/AppContext';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit,OnDestroy {

  constructor(private app: AppContext) {

  }

  ngOnInit() {
    
  }

  ngAfterViewInit() {
    var that = this;
    var menuState = localStorage.getItem('menuState');
    if (menuState == 'pinned') {
      this.app.AppTheme.pinMenu();
    }

    setTimeout(() => {
      this.app.setUserSubject({
        id: 1, name: 'gmaha', fullName: 'Girish Mahajan', isAdmin: true, role: 'Administrator', roles: ['Administrator'], image: 'noAvatarSmall.png', imageUrl: '/assets/images/noAvatarSmall.png'
      });

      
      window['loadingScreen'].finish();

    }, 1000);
  }

  ngOnDestroy(): void {
    
  }

}

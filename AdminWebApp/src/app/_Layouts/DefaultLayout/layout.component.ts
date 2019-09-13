import { Component, OnInit } from '@angular/core';
import { AppContext, User } from '../../services/AppContext';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.html'
})
export class LayoutComponent implements OnInit {

  user: User = null;
  subscription: Subscription;

  constructor(private app:AppContext) {
    
  }

  ngOnInit() {
    this.subscription =  this.app.getUserAsync().subscribe(o => {
      this.user = o;
    });
  }

  ngAfterViewInit() {

  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  onMenuToggle() {
    console.log(this.app.AppTheme.isMenuPinned());
    var menuState = this.app.AppTheme.isMenuPinned() == false ? 'pinned' : '';
    localStorage.setItem('menuState', menuState);
  }
}

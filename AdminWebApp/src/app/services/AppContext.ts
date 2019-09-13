import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppContext {

  private userSubject: Subject<IUser>;

  //User
  private _user: IUser;
  public get User(): IUser {
    return this._user;
  }
  /////

  //AppTheme
  private _appTheme: IAppTheme;
  public get AppTheme(): IAppTheme {
    return this._appTheme;
  }
  /////

  constructor() {
    this.userSubject = new Subject();
    this._appTheme = {
      blankImageUrl: 'data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7',
      isMenuPinned: () => {
        return (window as any).materialadmin.AppNavigation.getMenuState() == 1;
      },
      pinMenu: () => {
        (window as any).materialadmin.AppNavigation._handleMenuToggleClick()
      }
    }
  }

  setUserSubject(user: IUser) {
    this._user = user;
    this.userSubject.next(user);
  }

  getUserAsync(): Subject<IUser> {
    return this.userSubject;
  }
}

interface IAppTheme {
  blankImageUrl:string;
  isMenuPinned(): boolean;
  pinMenu(): void;
}


export interface IUser {
  id: number;
  name: string;
  image: string;
  imageUrl: string;
  fullName: string;
  roles: string[];
  role: string;
  isAdmin: boolean;
}

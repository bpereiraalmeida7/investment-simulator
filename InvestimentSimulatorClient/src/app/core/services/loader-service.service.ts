import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LoaderService {
  public loaderState: EventEmitter<boolean> = new EventEmitter<boolean>();

  public show(): void {
    this.loaderState.emit(true);
  }

  public hide(): void {
    this.loaderState.emit(false);
  }
}
import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appHighlight]'
})
export class HighlightDirective   {
  @Input() appHighlight = '';
  @HostListener('mouseenter') onMouseEnter() {
    this.highlight(this.appHighlight);
  }
  @HostListener('mouseleave') onMouseLeave() {
    this.highlight('');
  }
  constructor(private ef:ElementRef) {
   // this.ef.nativeElement.style.backgroundColor = 'yellow';
   }
  public highlight(color:string){
    this.ef.nativeElement.style.backgroundColor = color;
  }

}

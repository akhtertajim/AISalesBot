class SpeechService {
    synth;
    constructor(){
       this.synth = window.speechSynthesis;
    }
    speak(text) {
        const msg = new SpeechSynthesisUtterance(text); 
        this.synth.speak(msg);
    };
    interrupt(){
        if(this.synth!=null || this.synth !=='undefined'){
          this.synth.cancel();
        }    
    };   

}

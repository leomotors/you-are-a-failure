import{S as Tt,i as Ht,s as St,l as yo,g as ke,n as $o,o as b,p as bo,q as I,d as s,v as Io,F as xo,J as ko,K as Do,L as Ao,e as l,t as h,k as n,c as o,a as r,h as u,m as i,b as c,I as t,j as To,M as xe,C as yl,N as _o,z as Ho,O as At,P as wo,Q as So,w as k,x as D,y as A,B as T}from"../chunks/vendor-23be4776.js";function Po(y){let e;const f=y[2].default,m=xo(f,y,y[1],null);return{c(){m&&m.c()},l(d){m&&m.l(d)},m(d,g){m&&m.m(d,g),e=!0},p(d,g){m&&m.p&&(!e||g&2)&&ko(m,f,d,d[1],e?Ao(f,d[1],g,null):Do(d[1]),null)},i(d){e||(I(m,d),e=!0)},o(d){b(m,d),e=!1},d(d){m&&m.d(d)}}}function Mo(y){let e,f,m,d,g;return{c(){e=l("h2"),f=h(`1.0.69 will be released in
    `),m=l("br"),d=n(),g=h(y[0]),this.h()},l(p){e=o(p,"H2",{class:!0});var w=r(e);f=u(w,`1.0.69 will be released in
    `),m=o(w,"BR",{}),d=i(w),g=u(w,y[0]),w.forEach(s),this.h()},h(){c(e,"class","font-bold")},m(p,w){ke(p,e,w),t(e,f),t(e,m),t(e,d),t(e,g)},p(p,w){w&1&&To(g,p[0])},i:xe,o:xe,d(p){p&&s(e)}}}function Vo(y){let e,f,m,d;const g=[Mo,Po],p=[];function w(v,E){return v[0]?0:1}return e=w(y),f=p[e]=g[e](y),{c(){f.c(),m=yo()},l(v){f.l(v),m=yo()},m(v,E){p[e].m(v,E),ke(v,m,E),d=!0},p(v,[E]){let $=e;e=w(v),e===$?p[e].p(v,E):($o(),b(p[$],1,1,()=>{p[$]=null}),bo(),f=p[e],f?f.p(v,E):(f=p[e]=g[e](v),f.c()),I(f,1),f.m(m.parentNode,m))},i(v){d||(I(f),d=!0)},o(v){b(f),d=!1},d(v){p[e].d(v),v&&s(m)}}}function vl(y){return y>=10?`${y}`:`0${y}`}function Co(y,e,f){let{$$slots:m={},$$scope:d}=e;const g=new Date("1 Apr 2022 UTC+0");let p="Loading...";function w(){let v=g.getTime()-new Date().getTime();if(v<0)return"";v=Math.floor(v/1e3);let E="";v<0&&(E="-",v=-v);const $=v%60,Z=Math.floor(v/60),x=Z%60,Q=Math.floor(Z/60),V=Q%24,De=Math.floor(Q/24);return`${E}${De}:${vl(V)}:${vl(x)}:${vl($)}`}return Io(()=>{const v=setInterval(()=>{f(0,p=w())},1e3);return()=>clearInterval(v)}),y.$$set=v=>{"$$scope"in v&&f(1,d=v.$$scope)},[p,d,m]}class qo extends Tt{constructor(e){super();Ht(this,e,Co,Vo,St,{})}}function jo(y){let e,f,m,d=[{class:"mx-auto"},{src:f=y[2](y[0])},{alt:""},{width:m=y[1]?960:640},y[3]],g={};for(let p=0;p<d.length;p+=1)g=yl(g,d[p]);return{c(){e=l("img"),this.h()},l(p){e=o(p,"IMG",{class:!0,src:!0,alt:!0,width:!0}),this.h()},h(){_o(e,g)},m(p,w){ke(p,e,w)},p(p,[w]){_o(e,g=Ho(d,[{class:"mx-auto"},w&1&&!At(e.src,f=p[2](p[0]))&&{src:f},{alt:""},w&2&&m!==(m=p[1]?960:640)&&{width:m},w&8&&p[3]]))},i:xe,o:xe,d(p){p&&s(e)}}}function Go(y,e,f){const m=["img","full"];let d=wo(e,m),{img:g}=e,{full:p=void 0}=e;const w={"Emotional Damage GIF":"https://c.tenor.com/K9-SqJMNjkEAAAAC/emotional-damage.gif","Adagaki Aki":"AdagakiAki.webp","Levi to Erwin":"https://i.ytimg.com/vi/0Hp-U63b56s/maxresdefault.jpg","Zeke Monke":"https://sportshub.cbsistatic.com/i/2022/01/11/e3a2e49e-5b45-48f7-a406-2a094aceb6b4/attack-on-titan-season-4-zeke-survives.jpg","Eren Manipulates Grisha":"https://i.ytimg.com/vi/W2R4aOkT7cc/maxresdefault.jpg"};function v(E){var $;return($=w[E])!=null?$:E}return y.$$set=E=>{e=yl(yl({},e),So(E)),f(3,d=wo(e,m)),"img"in E&&f(0,g=E.img),"full"in E&&f(1,p=E.full)},[g,p,v,d]}class M extends Tt{constructor(e){super();Ht(this,e,Go,jo,St,{img:0,full:1})}}function No(y){let e,f,m;return{c(){e=l("div"),f=l("iframe"),this.h()},l(d){e=o(d,"DIV",{class:!0});var g=r(e);f=o(g,"IFRAME",{class:!0,src:!0,title:!0,frameborder:!0,allow:!0}),r(f).forEach(s),g.forEach(s),this.h()},h(){c(f,"class","mx-auto responsive-iframe svelte-pzipwd"),At(f.src,m=y[0])||c(f,"src",m),c(f,"title","YouTube video player"),c(f,"frameborder","0"),c(f,"allow","accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"),f.allowFullscreen=!0,c(e,"class","container mx-auto svelte-pzipwd")},m(d,g){ke(d,e,g),t(e,f)},p(d,[g]){g&1&&!At(f.src,m=d[0])&&c(f,"src",m)},i:xe,o:xe,d(d){d&&s(e)}}}function Wo(y,e,f){let{src:m}=e;return y.$$set=d=>{"src"in d&&f(0,m=d.src)},[m]}class Eo extends Tt{constructor(e){super();Ht(this,e,Wo,No,St,{src:0})}}function Fo(y){let e,f,m;return{c(){e=l("a"),f=l("img"),this.h()},l(d){e=o(d,"A",{href:!0,target:!0,rel:!0});var g=r(e);f=o(g,"IMG",{class:!0,alt:!0,src:!0,width:!0}),g.forEach(s),this.h()},h(){c(f,"class","my-10 mx-auto"),c(f,"alt","Get it from Microsoft Store"),At(f.src,m="https://getbadgecdn.azureedge.net/images/English_L.png")||c(f,"src",m),c(f,"width","500"),c(e,"href","https://www.microsoft.com/store/productId/9NJ5TZW6MDGL"),c(e,"target","_blank"),c(e,"rel","noopener")},m(d,g){ke(d,e,g),t(e,f)},d(d){d&&s(e)}}}function Lo(y){let e,f,m,d,g,p,w,v,E,$,Z,x,Q,V,De,Pt,X,Mt,Vt,Ae,Ct,qt,jt,Te,Gt,ee,Nt,Wt,te,Ft,Lt,ae,Rt,Yt,se,Ut,zt,He,Ot,C,Bt,Se,Pe,Jt,Kt,Me,Zt,q,Qt,le,Xt,ea,Ve,ta,j,aa,oe,sa,la,Ce,oa,qe,ra,na,je,ia,G,ha,re,ua,ca,Ge,fa,Ne,da,ma,We,pa,N,ga,ne,va,ie,ya,_a,he,wa,Ea,Fe,$a,W,ba,Le,Ia,xa,ka,Re,Da,Aa,F,Ta,ue,Ha,Sa,Pa,Ye,Ma,L,Va,ce,Ca,qa,fe,ja,Ga,Ue,Na,ze,Wa,de,Fa,La,me,Ra,Ya,Oe,Ua,R,za,pe,Oa,Ba,Be,Ja,Y,Ka,Je,Za,U,Qa,Ke,Xa,es,ts,H,as,Ze,ss,ls,Qe,os,rs,ns,Xe,is,hs,z,us,et,cs,tt,fs,ds,at,ms,ps,st,gs,ge,vs,ys,lt,_s,ot,ws,Es,rt,$s,O,bs,nt,Is,it,xs,ks,B,Ds,ht,As,Ts,Hs,J,Ss,ut,Ps,Ms,Vs,ve,Cs,qs,ct,js,Gs,ft,Ns,Ws,K,Fs,ye,Ls,Rs,dt,Ys,mt,Us,zs,pt,Os,Bs,_e,Js,Ks,gt,Zs,Qs,we,Xs,el,vt,tl,al,Ee,sl,ll,yt,ol,rl,$e,nl,il,_t,hl,ul,be,cl,fl,S,dl,wt,ml,$t;return q=new M({props:{img:"Emotional Damage GIF"}}),j=new M({props:{img:"Adagaki Aki"}}),G=new M({props:{img:"Levi to Erwin"}}),N=new M({props:{img:"Zeke Monke"}}),L=new Eo({props:{src:"https://www.youtube.com/embed/lO9K7VMFo2Y"}}),R=new M({props:{img:"Eren Manipulates Grisha"}}),Y=new Eo({props:{src:"https://www.youtube.com/embed/bRUzZkGAWr4?start=11"}}),z=new M({props:{img:"MySetGoal.webp",full:!0}}),O=new M({props:{img:"screenshots/failure.webp",full:!0}}),K=new M({props:{img:"screenshots/statistics.webp",full:!0}}),S=new qo({props:{$$slots:{default:[Fo]},$$scope:{ctx:y}}}),{c(){e=l("main"),f=l("div"),m=n(),d=l("h1"),g=h("You are a Failure!"),p=n(),w=l("p"),v=h("(with Asian Accent)"),E=n(),$=l("div"),Z=n(),x=l("p"),Q=h("So you applied to your "),V=l("i"),De=h("Dream College"),Pt=h(` a fews month ago, and today you
    wake up in the morning to see a well written
    `),X=l("span"),Mt=h("reused"),Vt=n(),Ae=l("strong"),Ct=h("Rejection Letter"),qt=h("."),jt=n(),Te=l("div"),Gt=n(),ee=l("p"),Nt=h(`The Admissions Committee has completed its review of your application. I am
    very sorry to tell you that you were not admitted to the MIT Class of 2026.`),Wt=n(),te=l("p"),Ft=h(`The Committee on Admissions has completed its meetings, and I am very sorry
    to inform you that we cannot offer you admission to the Class of 2026.
    (Harvard)`),Lt=n(),ae=l("p"),Rt=h(`I am sorry to inform you that we are unable to admit you to Princeton
    University this year.`),Yt=n(),se=l("p"),Ut=h(`The Yale Admissions Committee has completed its evaluation of this year\u2019s
    candidates, and I am genuinely sorry that we are not able to offer you a
    place in the Class of 2026.`),zt=n(),He=l("div"),Ot=n(),C=l("p"),Bt=h("That is "),Se=l("strong"),Pe=l("em"),Jt=h("Emotional Damage!"),Kt=n(),Me=l("div"),Zt=n(),k(q.$$.fragment),Qt=n(),le=l("p"),Xt=h('"Emotional Damage" by Steven He'),ea=n(),Ve=l("div"),ta=n(),k(j.$$.fragment),aa=n(),oe=l("p"),sa=h("\u5B89\u9054\u57A3\u611B\u59EB from \u653F\u5B97\u304F\u3093\u306E\u30EA\u30D9\u30F3\u30B8"),la=n(),Ce=l("div"),oa=n(),qe=l("h3"),ra=h(`So, your Dream just has been shattered, what should you do with your life
    next?`),na=n(),je=l("div"),ia=n(),k(G.$$.fragment),ha=n(),re=l("h4"),ua=h("\u5922\u3092\u8AE6\u3081\u3066\u6B7B\u3093\u3067\u304F\u308C"),ca=n(),Ge=l("div"),fa=n(),Ne=l("h2"),da=h("Just Kidding,"),ma=n(),We=l("div"),pa=n(),k(N.$$.fragment),ga=n(),ne=l("h3"),va=h(`We just have to keep moving forward, right?
    `),ie=l("span"),ya=h("Eren."),_a=n(),he=l("h4"),wa=h("\u4FFA\u9054\u306F \u305F\u3060 \u9032\u3080\u3060\u3051\u3060\u3088\u306A \u30A8\u30EC\u30F3"),Ea=n(),Fe=l("div"),$a=n(),W=l("p"),ba=h("You may not achieve your "),Le=l("i"),Ia=h("dream school"),xa=h(` today, but you can try again in
    next 4 years. Prepare well and aim for the same school in Graduate Level.`),ka=n(),Re=l("h4"),Da=h(`To fit at World's Top University, you need to be perfect in everything, and
    you should start preparing now.`),Aa=n(),F=l("h3"),Ta=h("To achieve that, you need "),ue=l("strong"),Ha=h("motivation"),Sa=h("."),Pa=n(),Ye=l("div"),Ma=n(),k(L.$$.fragment),Va=n(),ce=l("p"),Ca=h(`I have faced many failures in my life. Failure is viewed as a bad thing, but
    it also gives me overwhelming motivation. I have grown because I didn't
    wallow in misery with my past failures. The perseverance to keep moving
    forward is the key to success.`),qa=n(),fe=l("p"),ja=h(`This is a real part of my essay to MIT. Not sure if this is the reason they
    reject me. \u{1F602}`),Ga=n(),Ue=l("div"),Na=n(),ze=l("div"),Wa=n(),de=l("p"),Fa=h("I refused to lose without a fight ..."),La=n(),me=l("p"),Ra=h(`If I lose it all, slip and fall. I will never look away. If I lose it all,
    lose it all, lose it all ...`),Ya=n(),Oe=l("div"),Ua=n(),k(R.$$.fragment),za=n(),pe=l("p"),Oa=h("\u9032\u307F\u7D9A\u3051\u308B\u3093\u3060 \u6B7B\u3093\u3067\u3082 \u6B7B\u3093\u3060\u5F8C\u3082"),Ba=n(),Be=l("div"),Ja=n(),k(Y.$$.fragment),Ka=n(),Je=l("div"),Za=n(),U=l("h4"),Qa=h(`Listened to The Rumbling gives you Hype. But if you look closely, that is
    not enough and you will eventually become `),Ke=l("i"),Xa=h("failure"),es=h(" again."),ts=n(),H=l("p"),as=h("I proudly present to you, The Asian Solution. "),Ze=l("b"),ss=h("An Insult"),ls=h(`, delivering
    maximum `),Qe=l("i"),os=h("emotional damage"),rs=h(" that will push you forward."),ns=n(),Xe=l("h3"),is=h("So, I have set my goal."),hs=n(),k(z.$$.fragment),us=n(),et=l("div"),cs=n(),tt=l("h3"),fs=h("I will keep doing this to warn me about my goal,"),ds=n(),at=l("h4"),ms=h("and I need assistance for that."),ps=n(),st=l("div"),gs=n(),ge=l("h1"),vs=h("Introducing..."),ys=n(),lt=l("div"),_s=n(),ot=l("h2"),ws=h("You are a Failure!"),Es=n(),rt=l("div"),$s=n(),k(O.$$.fragment),bs=n(),nt=l("div"),Is=n(),it=l("h3"),xs=h(`An App that will help you on keeping motivation and fire, with unique
    technique from Asian Descendant`),ks=n(),B=l("p"),Ds=h("Log in to this app daily to watch some "),ht=l("i"),As=h("motivational videos"),Ts=h(` by Steven He,
    keep doing this until you accomplished your goal!`),Hs=n(),J=l("p"),Ss=h("(And big \u{1F647}\u200D\u2642\uFE0F to him for creating a very "),ut=l("i"),Ps=h("cultured"),Ms=h(" meme.)"),Vs=n(),ve=l("p"),Cs=h("Note: This app is made for entertainment purposes only!"),qs=n(),ct=l("h2"),js=h("\u2728Feature: Statistics"),Gs=n(),ft=l("p"),Ns=h("Show your friend how consistent you are into accomplishing your set goal!"),Ws=n(),k(K.$$.fragment),Fs=n(),ye=l("p"),Ls=h("long way to go..."),Rs=n(),dt=l("div"),Ys=n(),mt=l("h2"),Us=h("Download now for \u{1FA9F}Windows"),zs=n(),pt=l("h4"),Os=h("\u2705 Support from Windows 10 1903 (10.0.18362)"),Bs=n(),_e=l("p"),Js=h("if you use older than this, consider what you are using"),Ks=n(),gt=l("h4"),Zs=h("\u2705 Support 32-bit and 64-bit"),Qs=n(),we=l("p"),Xs=h("you use 32-bit in 2022? pathetic"),el=n(),vt=l("h4"),tl=h("\u2705 Support Windows 11's New Mica Material"),al=n(),Ee=l("p"),sl=h("which of course, only visible if you use Windows 11"),ll=n(),yt=l("h4"),ol=h("\u274C Steal your personal data"),rl=n(),$e=l("p"),nl=h("unlike ..."),il=n(),_t=l("h4"),hl=h("\u2705 Emotional Damage"),ul=n(),be=l("p"),cl=h("guaranteed damage by Steven He"),fl=n(),k(S.$$.fragment),dl=n(),wt=l("p"),ml=h("If you like this app, rate it 5\u2B50 and also \u2B50 my GitHub Repo!"),this.h()},l(_){e=o(_,"MAIN",{class:!0});var a=r(e);f=o(a,"DIV",{class:!0}),r(f).forEach(s),m=i(a),d=o(a,"H1",{});var Et=r(d);g=u(Et,"You are a Failure!"),Et.forEach(s),p=i(a),w=o(a,"P",{class:!0});var _l=r(w);v=u(_l,"(with Asian Accent)"),_l.forEach(s),E=i(a),$=o(a,"DIV",{class:!0}),r($).forEach(s),Z=i(a),x=o(a,"P",{});var P=r(x);Q=u(P,"So you applied to your "),V=o(P,"I",{});var wl=r(V);De=u(wl,"Dream College"),wl.forEach(s),Pt=u(P,` a fews month ago, and today you
    wake up in the morning to see a well written
    `),X=o(P,"SPAN",{class:!0});var El=r(X);Mt=u(El,"reused"),El.forEach(s),Vt=i(P),Ae=o(P,"STRONG",{});var $l=r(Ae);Ct=u($l,"Rejection Letter"),$l.forEach(s),qt=u(P,"."),P.forEach(s),jt=i(a),Te=o(a,"DIV",{class:!0}),r(Te).forEach(s),Gt=i(a),ee=o(a,"P",{class:!0});var bl=r(ee);Nt=u(bl,`The Admissions Committee has completed its review of your application. I am
    very sorry to tell you that you were not admitted to the MIT Class of 2026.`),bl.forEach(s),Wt=i(a),te=o(a,"P",{class:!0});var Il=r(te);Ft=u(Il,`The Committee on Admissions has completed its meetings, and I am very sorry
    to inform you that we cannot offer you admission to the Class of 2026.
    (Harvard)`),Il.forEach(s),Lt=i(a),ae=o(a,"P",{class:!0});var xl=r(ae);Rt=u(xl,`I am sorry to inform you that we are unable to admit you to Princeton
    University this year.`),xl.forEach(s),Yt=i(a),se=o(a,"P",{class:!0});var kl=r(se);Ut=u(kl,`The Yale Admissions Committee has completed its evaluation of this year\u2019s
    candidates, and I am genuinely sorry that we are not able to offer you a
    place in the Class of 2026.`),kl.forEach(s),zt=i(a),He=o(a,"DIV",{class:!0}),r(He).forEach(s),Ot=i(a),C=o(a,"P",{class:!0});var pl=r(C);Bt=u(pl,"That is "),Se=o(pl,"STRONG",{});var Dl=r(Se);Pe=o(Dl,"EM",{});var Al=r(Pe);Jt=u(Al,"Emotional Damage!"),Al.forEach(s),Dl.forEach(s),pl.forEach(s),Kt=i(a),Me=o(a,"DIV",{class:!0}),r(Me).forEach(s),Zt=i(a),D(q.$$.fragment,a),Qt=i(a),le=o(a,"P",{class:!0});var Tl=r(le);Xt=u(Tl,'"Emotional Damage" by Steven He'),Tl.forEach(s),ea=i(a),Ve=o(a,"DIV",{class:!0}),r(Ve).forEach(s),ta=i(a),D(j.$$.fragment,a),aa=i(a),oe=o(a,"P",{class:!0});var Hl=r(oe);sa=u(Hl,"\u5B89\u9054\u57A3\u611B\u59EB from \u653F\u5B97\u304F\u3093\u306E\u30EA\u30D9\u30F3\u30B8"),Hl.forEach(s),la=i(a),Ce=o(a,"DIV",{class:!0}),r(Ce).forEach(s),oa=i(a),qe=o(a,"H3",{});var Sl=r(qe);ra=u(Sl,`So, your Dream just has been shattered, what should you do with your life
    next?`),Sl.forEach(s),na=i(a),je=o(a,"DIV",{class:!0}),r(je).forEach(s),ia=i(a),D(G.$$.fragment,a),ha=i(a),re=o(a,"H4",{class:!0});var Pl=r(re);ua=u(Pl,"\u5922\u3092\u8AE6\u3081\u3066\u6B7B\u3093\u3067\u304F\u308C"),Pl.forEach(s),ca=i(a),Ge=o(a,"DIV",{class:!0}),r(Ge).forEach(s),fa=i(a),Ne=o(a,"H2",{});var Ml=r(Ne);da=u(Ml,"Just Kidding,"),Ml.forEach(s),ma=i(a),We=o(a,"DIV",{class:!0}),r(We).forEach(s),pa=i(a),D(N.$$.fragment,a),ga=i(a),ne=o(a,"H3",{});var gl=r(ne);va=u(gl,`We just have to keep moving forward, right?
    `),ie=o(gl,"SPAN",{class:!0});var Vl=r(ie);ya=u(Vl,"Eren."),Vl.forEach(s),gl.forEach(s),_a=i(a),he=o(a,"H4",{class:!0});var Cl=r(he);wa=u(Cl,"\u4FFA\u9054\u306F \u305F\u3060 \u9032\u3080\u3060\u3051\u3060\u3088\u306A \u30A8\u30EC\u30F3"),Cl.forEach(s),Ea=i(a),Fe=o(a,"DIV",{class:!0}),r(Fe).forEach(s),$a=i(a),W=o(a,"P",{});var bt=r(W);ba=u(bt,"You may not achieve your "),Le=o(bt,"I",{});var ql=r(Le);Ia=u(ql,"dream school"),ql.forEach(s),xa=u(bt,` today, but you can try again in
    next 4 years. Prepare well and aim for the same school in Graduate Level.`),bt.forEach(s),ka=i(a),Re=o(a,"H4",{});var jl=r(Re);Da=u(jl,`To fit at World's Top University, you need to be perfect in everything, and
    you should start preparing now.`),jl.forEach(s),Aa=i(a),F=o(a,"H3",{});var It=r(F);Ta=u(It,"To achieve that, you need "),ue=o(It,"STRONG",{class:!0});var Gl=r(ue);Ha=u(Gl,"motivation"),Gl.forEach(s),Sa=u(It,"."),It.forEach(s),Pa=i(a),Ye=o(a,"DIV",{class:!0}),r(Ye).forEach(s),Ma=i(a),D(L.$$.fragment,a),Va=i(a),ce=o(a,"P",{class:!0});var Nl=r(ce);Ca=u(Nl,`I have faced many failures in my life. Failure is viewed as a bad thing, but
    it also gives me overwhelming motivation. I have grown because I didn't
    wallow in misery with my past failures. The perseverance to keep moving
    forward is the key to success.`),Nl.forEach(s),qa=i(a),fe=o(a,"P",{class:!0});var Wl=r(fe);ja=u(Wl,`This is a real part of my essay to MIT. Not sure if this is the reason they
    reject me. \u{1F602}`),Wl.forEach(s),Ga=i(a),Ue=o(a,"DIV",{class:!0}),r(Ue).forEach(s),Na=i(a),ze=o(a,"DIV",{class:!0}),r(ze).forEach(s),Wa=i(a),de=o(a,"P",{class:!0});var Fl=r(de);Fa=u(Fl,"I refused to lose without a fight ..."),Fl.forEach(s),La=i(a),me=o(a,"P",{class:!0});var Ll=r(me);Ra=u(Ll,`If I lose it all, slip and fall. I will never look away. If I lose it all,
    lose it all, lose it all ...`),Ll.forEach(s),Ya=i(a),Oe=o(a,"DIV",{class:!0}),r(Oe).forEach(s),Ua=i(a),D(R.$$.fragment,a),za=i(a),pe=o(a,"P",{class:!0});var Rl=r(pe);Oa=u(Rl,"\u9032\u307F\u7D9A\u3051\u308B\u3093\u3060 \u6B7B\u3093\u3067\u3082 \u6B7B\u3093\u3060\u5F8C\u3082"),Rl.forEach(s),Ba=i(a),Be=o(a,"DIV",{class:!0}),r(Be).forEach(s),Ja=i(a),D(Y.$$.fragment,a),Ka=i(a),Je=o(a,"DIV",{class:!0}),r(Je).forEach(s),Za=i(a),U=o(a,"H4",{});var xt=r(U);Qa=u(xt,`Listened to The Rumbling gives you Hype. But if you look closely, that is
    not enough and you will eventually become `),Ke=o(xt,"I",{});var Yl=r(Ke);Xa=u(Yl,"failure"),Yl.forEach(s),es=u(xt," again."),xt.forEach(s),ts=i(a),H=o(a,"P",{});var Ie=r(H);as=u(Ie,"I proudly present to you, The Asian Solution. "),Ze=o(Ie,"B",{});var Ul=r(Ze);ss=u(Ul,"An Insult"),Ul.forEach(s),ls=u(Ie,`, delivering
    maximum `),Qe=o(Ie,"I",{});var zl=r(Qe);os=u(zl,"emotional damage"),zl.forEach(s),rs=u(Ie," that will push you forward."),Ie.forEach(s),ns=i(a),Xe=o(a,"H3",{});var Ol=r(Xe);is=u(Ol,"So, I have set my goal."),Ol.forEach(s),hs=i(a),D(z.$$.fragment,a),us=i(a),et=o(a,"DIV",{class:!0}),r(et).forEach(s),cs=i(a),tt=o(a,"H3",{});var Bl=r(tt);fs=u(Bl,"I will keep doing this to warn me about my goal,"),Bl.forEach(s),ds=i(a),at=o(a,"H4",{});var Jl=r(at);ms=u(Jl,"and I need assistance for that."),Jl.forEach(s),ps=i(a),st=o(a,"DIV",{class:!0}),r(st).forEach(s),gs=i(a),ge=o(a,"H1",{class:!0});var Kl=r(ge);vs=u(Kl,"Introducing..."),Kl.forEach(s),ys=i(a),lt=o(a,"DIV",{class:!0}),r(lt).forEach(s),_s=i(a),ot=o(a,"H2",{});var Zl=r(ot);ws=u(Zl,"You are a Failure!"),Zl.forEach(s),Es=i(a),rt=o(a,"DIV",{class:!0}),r(rt).forEach(s),$s=i(a),D(O.$$.fragment,a),bs=i(a),nt=o(a,"DIV",{class:!0}),r(nt).forEach(s),Is=i(a),it=o(a,"H3",{});var Ql=r(it);xs=u(Ql,`An App that will help you on keeping motivation and fire, with unique
    technique from Asian Descendant`),Ql.forEach(s),ks=i(a),B=o(a,"P",{});var kt=r(B);Ds=u(kt,"Log in to this app daily to watch some "),ht=o(kt,"I",{});var Xl=r(ht);As=u(Xl,"motivational videos"),Xl.forEach(s),Ts=u(kt,` by Steven He,
    keep doing this until you accomplished your goal!`),kt.forEach(s),Hs=i(a),J=o(a,"P",{});var Dt=r(J);Ss=u(Dt,"(And big \u{1F647}\u200D\u2642\uFE0F to him for creating a very "),ut=o(Dt,"I",{});var eo=r(ut);Ps=u(eo,"cultured"),eo.forEach(s),Ms=u(Dt," meme.)"),Dt.forEach(s),Vs=i(a),ve=o(a,"P",{class:!0});var to=r(ve);Cs=u(to,"Note: This app is made for entertainment purposes only!"),to.forEach(s),qs=i(a),ct=o(a,"H2",{});var ao=r(ct);js=u(ao,"\u2728Feature: Statistics"),ao.forEach(s),Gs=i(a),ft=o(a,"P",{});var so=r(ft);Ns=u(so,"Show your friend how consistent you are into accomplishing your set goal!"),so.forEach(s),Ws=i(a),D(K.$$.fragment,a),Fs=i(a),ye=o(a,"P",{class:!0});var lo=r(ye);Ls=u(lo,"long way to go..."),lo.forEach(s),Rs=i(a),dt=o(a,"DIV",{class:!0}),r(dt).forEach(s),Ys=i(a),mt=o(a,"H2",{});var oo=r(mt);Us=u(oo,"Download now for \u{1FA9F}Windows"),oo.forEach(s),zs=i(a),pt=o(a,"H4",{});var ro=r(pt);Os=u(ro,"\u2705 Support from Windows 10 1903 (10.0.18362)"),ro.forEach(s),Bs=i(a),_e=o(a,"P",{class:!0});var no=r(_e);Js=u(no,"if you use older than this, consider what you are using"),no.forEach(s),Ks=i(a),gt=o(a,"H4",{});var io=r(gt);Zs=u(io,"\u2705 Support 32-bit and 64-bit"),io.forEach(s),Qs=i(a),we=o(a,"P",{class:!0});var ho=r(we);Xs=u(ho,"you use 32-bit in 2022? pathetic"),ho.forEach(s),el=i(a),vt=o(a,"H4",{});var uo=r(vt);tl=u(uo,"\u2705 Support Windows 11's New Mica Material"),uo.forEach(s),al=i(a),Ee=o(a,"P",{class:!0});var co=r(Ee);sl=u(co,"which of course, only visible if you use Windows 11"),co.forEach(s),ll=i(a),yt=o(a,"H4",{});var fo=r(yt);ol=u(fo,"\u274C Steal your personal data"),fo.forEach(s),rl=i(a),$e=o(a,"P",{class:!0});var mo=r($e);nl=u(mo,"unlike ..."),mo.forEach(s),il=i(a),_t=o(a,"H4",{});var po=r(_t);hl=u(po,"\u2705 Emotional Damage"),po.forEach(s),ul=i(a),be=o(a,"P",{class:!0});var go=r(be);cl=u(go,"guaranteed damage by Steven He"),go.forEach(s),fl=i(a),D(S.$$.fragment,a),dl=i(a),wt=o(a,"P",{});var vo=r(wt);ml=u(vo,"If you like this app, rate it 5\u2B50 and also \u2B50 my GitHub Repo!"),vo.forEach(s),a.forEach(s),this.h()},h(){c(f,"class","t-30 svelte-1fyxh8g"),c(w,"class","text-lg text-slate-700"),c($,"class","t-40 svelte-1fyxh8g"),c(X,"class","line-through"),c(Te,"class","t-5 svelte-1fyxh8g"),c(ee,"class","quote text-lg svelte-1fyxh8g"),c(te,"class","quote text-lg svelte-1fyxh8g"),c(ae,"class","quote text-lg svelte-1fyxh8g"),c(se,"class","quote text-lg svelte-1fyxh8g"),c(He,"class","t-5 svelte-1fyxh8g"),c(C,"class","text-4xl"),c(Me,"class","t-5 svelte-1fyxh8g"),c(le,"class","text-xl"),c(Ve,"class","t-5 svelte-1fyxh8g"),c(oe,"class","text-xl jp svelte-1fyxh8g"),c(Ce,"class","t-30 svelte-1fyxh8g"),c(je,"class","t-10 svelte-1fyxh8g"),c(re,"class","quote-jp svelte-1fyxh8g"),c(Ge,"class","t-20 svelte-1fyxh8g"),c(We,"class","t-5 svelte-1fyxh8g"),c(ie,"class","line-through"),c(he,"class","quote-jp svelte-1fyxh8g"),c(Fe,"class","t-30 svelte-1fyxh8g"),c(ue,"class","underline"),c(Ye,"class","t-30 svelte-1fyxh8g"),c(ce,"class","quote svelte-1fyxh8g"),c(fe,"class","text-xl text-slate-700"),c(Ue,"class","t-5 svelte-1fyxh8g"),c(ze,"class","t-20 svelte-1fyxh8g"),c(de,"class","quote svelte-1fyxh8g"),c(me,"class","quote svelte-1fyxh8g"),c(Oe,"class","t-10 svelte-1fyxh8g"),c(pe,"class","quote-jp svelte-1fyxh8g"),c(Be,"class","t-10 svelte-1fyxh8g"),c(Je,"class","t-10 svelte-1fyxh8g"),c(et,"class","t-10 svelte-1fyxh8g"),c(st,"class","t-40 svelte-1fyxh8g"),c(ge,"class","text-5xl sm:text-6xl lg:text-7xl xl:text-8xl"),c(lt,"class","t-5 svelte-1fyxh8g"),c(rt,"class","t-10 svelte-1fyxh8g"),c(nt,"class","t-5 svelte-1fyxh8g"),c(ve,"class","italic text-xl"),c(ye,"class","italic text-xl"),c(dt,"class","t-10 svelte-1fyxh8g"),c(_e,"class","bruh svelte-1fyxh8g"),c(we,"class","bruh svelte-1fyxh8g"),c(Ee,"class","bruh svelte-1fyxh8g"),c($e,"class","bruh svelte-1fyxh8g"),c(be,"class","bruh line-through svelte-1fyxh8g"),c(e,"class","prose prose-lg sm:prose-xl lg:prose-2xl pb-20")},m(_,a){ke(_,e,a),t(e,f),t(e,m),t(e,d),t(d,g),t(e,p),t(e,w),t(w,v),t(e,E),t(e,$),t(e,Z),t(e,x),t(x,Q),t(x,V),t(V,De),t(x,Pt),t(x,X),t(X,Mt),t(x,Vt),t(x,Ae),t(Ae,Ct),t(x,qt),t(e,jt),t(e,Te),t(e,Gt),t(e,ee),t(ee,Nt),t(e,Wt),t(e,te),t(te,Ft),t(e,Lt),t(e,ae),t(ae,Rt),t(e,Yt),t(e,se),t(se,Ut),t(e,zt),t(e,He),t(e,Ot),t(e,C),t(C,Bt),t(C,Se),t(Se,Pe),t(Pe,Jt),t(e,Kt),t(e,Me),t(e,Zt),A(q,e,null),t(e,Qt),t(e,le),t(le,Xt),t(e,ea),t(e,Ve),t(e,ta),A(j,e,null),t(e,aa),t(e,oe),t(oe,sa),t(e,la),t(e,Ce),t(e,oa),t(e,qe),t(qe,ra),t(e,na),t(e,je),t(e,ia),A(G,e,null),t(e,ha),t(e,re),t(re,ua),t(e,ca),t(e,Ge),t(e,fa),t(e,Ne),t(Ne,da),t(e,ma),t(e,We),t(e,pa),A(N,e,null),t(e,ga),t(e,ne),t(ne,va),t(ne,ie),t(ie,ya),t(e,_a),t(e,he),t(he,wa),t(e,Ea),t(e,Fe),t(e,$a),t(e,W),t(W,ba),t(W,Le),t(Le,Ia),t(W,xa),t(e,ka),t(e,Re),t(Re,Da),t(e,Aa),t(e,F),t(F,Ta),t(F,ue),t(ue,Ha),t(F,Sa),t(e,Pa),t(e,Ye),t(e,Ma),A(L,e,null),t(e,Va),t(e,ce),t(ce,Ca),t(e,qa),t(e,fe),t(fe,ja),t(e,Ga),t(e,Ue),t(e,Na),t(e,ze),t(e,Wa),t(e,de),t(de,Fa),t(e,La),t(e,me),t(me,Ra),t(e,Ya),t(e,Oe),t(e,Ua),A(R,e,null),t(e,za),t(e,pe),t(pe,Oa),t(e,Ba),t(e,Be),t(e,Ja),A(Y,e,null),t(e,Ka),t(e,Je),t(e,Za),t(e,U),t(U,Qa),t(U,Ke),t(Ke,Xa),t(U,es),t(e,ts),t(e,H),t(H,as),t(H,Ze),t(Ze,ss),t(H,ls),t(H,Qe),t(Qe,os),t(H,rs),t(e,ns),t(e,Xe),t(Xe,is),t(e,hs),A(z,e,null),t(e,us),t(e,et),t(e,cs),t(e,tt),t(tt,fs),t(e,ds),t(e,at),t(at,ms),t(e,ps),t(e,st),t(e,gs),t(e,ge),t(ge,vs),t(e,ys),t(e,lt),t(e,_s),t(e,ot),t(ot,ws),t(e,Es),t(e,rt),t(e,$s),A(O,e,null),t(e,bs),t(e,nt),t(e,Is),t(e,it),t(it,xs),t(e,ks),t(e,B),t(B,Ds),t(B,ht),t(ht,As),t(B,Ts),t(e,Hs),t(e,J),t(J,Ss),t(J,ut),t(ut,Ps),t(J,Ms),t(e,Vs),t(e,ve),t(ve,Cs),t(e,qs),t(e,ct),t(ct,js),t(e,Gs),t(e,ft),t(ft,Ns),t(e,Ws),A(K,e,null),t(e,Fs),t(e,ye),t(ye,Ls),t(e,Rs),t(e,dt),t(e,Ys),t(e,mt),t(mt,Us),t(e,zs),t(e,pt),t(pt,Os),t(e,Bs),t(e,_e),t(_e,Js),t(e,Ks),t(e,gt),t(gt,Zs),t(e,Qs),t(e,we),t(we,Xs),t(e,el),t(e,vt),t(vt,tl),t(e,al),t(e,Ee),t(Ee,sl),t(e,ll),t(e,yt),t(yt,ol),t(e,rl),t(e,$e),t($e,nl),t(e,il),t(e,_t),t(_t,hl),t(e,ul),t(e,be),t(be,cl),t(e,fl),A(S,e,null),t(e,dl),t(e,wt),t(wt,ml),$t=!0},p(_,[a]){const Et={};a&1&&(Et.$$scope={dirty:a,ctx:_}),S.$set(Et)},i(_){$t||(I(q.$$.fragment,_),I(j.$$.fragment,_),I(G.$$.fragment,_),I(N.$$.fragment,_),I(L.$$.fragment,_),I(R.$$.fragment,_),I(Y.$$.fragment,_),I(z.$$.fragment,_),I(O.$$.fragment,_),I(K.$$.fragment,_),I(S.$$.fragment,_),$t=!0)},o(_){b(q.$$.fragment,_),b(j.$$.fragment,_),b(G.$$.fragment,_),b(N.$$.fragment,_),b(L.$$.fragment,_),b(R.$$.fragment,_),b(Y.$$.fragment,_),b(z.$$.fragment,_),b(O.$$.fragment,_),b(K.$$.fragment,_),b(S.$$.fragment,_),$t=!1},d(_){_&&s(e),T(q),T(j),T(G),T(N),T(L),T(R),T(Y),T(z),T(O),T(K),T(S)}}}class Yo extends Tt{constructor(e){super();Ht(this,e,null,Lo,St,{})}}export{Yo as default};

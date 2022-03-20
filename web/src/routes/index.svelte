<script lang="ts">
  import Image from "$components/image.svelte";
  import Youtube from "$components/youtube.svelte";
</script>

<main class="prose prose-2xl pb-20">
  <div class="t-30" />
  <h1>You are a Failure!</h1>
  <p class="text-lg text-slate-700">(with Asian Accent)</p>
  <div class="t-40" />

  <p>
    So you applied to your <i>Dream College</i> a fews month ago, and today you
    wake up in the morning to see a well written
    <span class="line-through">reused</span>
    <strong>Rejection Letter</strong>.
  </p>

  <div class="t-5" />
  <p>That is <strong><i>Emotional Damage!</i></strong></p>
  <div class="t-10" />
  <Image img="Emotional Damage GIF" />
  <p class="text-xl">"Emotional Damage" by Steven He</p>

  <div class="t-5" />
  <Image img="Adagaki Aki" />
  <p class="text-xl jp">安達垣愛姫 from 政宗くんのリベンジ</p>

  <div class="t-30" />
  <h3>
    So, your Dream just has been shattered, what should you do with your life
    next?
  </h3>
  <div class="t-10" />

  <Image img="Levi to Erwin" />

  <h4 class="quote-jp">夢を諦めて死んでくれ</h4>

  <div class="t-20" />

  <h2>Just Kidding,</h2>

  <div class="t-5" />
  <Image img="Zeke Monke" />

  <h3>
    We just have to keep moving forward, right?
    <span class="line-through">Eren.</span>
  </h3>
  <h4 class="quote-jp">俺達は ただ 進むだけだよな エレン</h4>

  <div class="t-30" />
  <p>
    You may not achieve your <i>dream school</i> today, but you can try again in
    next 4 years. Prepare well and aim for the same school in Graduate Level.
  </p>

  <h4>
    To fit at World's Top University, you need to be perfect in everything, and
    you should start preparing now.
  </h4>

  <h3>
    To achieve that, you need <strong class="underline">motivation</strong>.
  </h3>

  <div class="t-30" />

  <Youtube src="https://www.youtube.com/embed/lO9K7VMFo2Y" />

  <p class="quote">
    I have faced many failures in my life. Failure is viewed as a bad thing, but
    it also gives me overwhelming motivation. I have grown because I didn't
    wallow in misery with my past failures. The perseverance to keep moving
    forward is the key to success.
  </p>

  <p class="text-xl text-slate-700">
    This is a real part of my essay to MIT. Not sure if this is the reason they
    reject me. 😂
  </p>
  <div class="t-5" />

  <div class="t-20" />

  <p class="quote">I refused to lose without a fight ...</p>

  <p class="quote">
    If I lose it all, slip and fall. I will never look away. If I lose it all,
    lose it all, lose it all ...
  </p>

  <div class="t-10" />
  <Image img="Eren Manipulates Grisha" />
  <p class="quote-jp">進み続けるんだ 死んでも 死んだ後も</p>
  <div class="t-10" />

  <Youtube src="https://www.youtube.com/embed/bRUzZkGAWr4?start=11" />

  <div class="t-10" />
  <h4>
    Listened to The Rumbling gives you Hype. But if you look closely, that is
    not enough and you will eventually become <i>failure</i> again.
  </h4>

  <p>
    I proudly present to you, The Asian Solution. <b>An Insult</b>, delivering
    maximum <i>emotional damage</i> that will push you forward.
  </p>

  <h3>So, I have set my goal.</h3>
  <Image img="MySetGoal.webp" full />

  <div class="t-10" />

  <h3>I will keep doing this to warn me about my goal,</h3>
  <h4>and I need assistance for that.</h4>

  <div class="t-40" />

  <h1 class="text-5xl sm:text-6xl lg:text-7xl xl:text-8xl">Introducing...</h1>
  <div class="t-5" />
  <h2>You are a Failure!</h2>
  <div class="t-10" />
  <Image img="FailureApp1.webp" full />

  <div class="t-5" />
  <h3>
    An App that will help you on keeping motivation and fire, with unique
    technique from Asian Descendant
  </h3>
  <p>
    Log in to this app daily to watch some <i>motivational videos</i> by Steven He,
    keep doing this until you accomplished your goal!
  </p>
  <p>And big 🙇‍♂️ to him for creating a very <i>cultured</i> meme.</p>

  <h2>✨Feature: Statistics</h2>
  <p>
    Show your friend how consistent you are into accomplishing your set goal!
  </p>
  <Image img="screenshots/statistics.webp" full />

  <h2>Download now for 🪟Windows</h2>
  <h4>✅ Support from Windows 10 2004 (10.0.19041)</h4>
  <h4>✅ Support Windows 11's New Mica Material</h4>
  <p><i>Will</i> be available in Microsoft Store (If they don't reject)</p>
</main>

<style lang="postcss">
  .quote:before {
    content: "\201C";
  }

  .quote:after {
    content: "\201D";
  }

  .quote-jp {
    @apply jp;
  }

  .quote-jp:before {
    content: "「";
  }

  .quote-jp:after {
    content: "」";
  }

  .jp {
    font-family: Inter, Yu Mincho;
  }

  .t-40 {
    height: 40vh;
  }

  .t-30 {
    height: 30vh;
  }

  .t-20 {
    height: 20vh;
  }

  .t-10 {
    height: 10vh;
  }

  .t-5 {
    height: 5vh;
  }
</style>

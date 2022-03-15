<script>
  import Image from "$components/image.svelte";
</script>

<main class="prose prose-2xl">
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

  <h4 class="text-slate-700 jp">「夢を諦めて死んでくれ」</h4>

  <div class="t-20" />

  <h2>Just Kidding,</h2>

  <div class="t-5" />
  <Image img="Zeke Monke" />

  <h3>
    We just have to keep moving forward, right?
    <span class="line-through">Eren.</span>
  </h3>
  <h4 class="text-slate-700 jp">俺達は ただ 進むだけだよな エレン</h4>

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

  <div class="t-10" />

  <iframe
    width="640"
    height="360"
    src="https://www.youtube.com/embed/lO9K7VMFo2Y"
    title="YouTube video player"
    frameborder="0"
    allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
    allowfullscreen
  />

  <p>
    &ldquo;I have faced many failures in my life. Failure is viewed as a bad
    thing, but it also gives me overwhelming motivation. I have grown because I
    didn't wallow in misery with my past failures. The perseverance to keep
    moving forward is the key to success.&rdquo;
  </p>

  <p class="text-xl text-slate-700">
    This is a real part of my essay to MIT. Not sure if this is the reason they
    reject me. 😂
  </p>
  <div class="t-5" />

  <h3>Nevertheless, I have set my goal.</h3>
  <Image img="My Set Goal" width="960" />

  <div class="t-10" />

  <h3>I will keep doing this to Warn me about my goal,</h3>
  <h4>and I need assistance for that.</h4>

  <div class="t-40" />

  <h1>Introducing...</h1>
  <div class="t-5" />
  <h2>You are a Failure!</h2>
  <div class="t-10" />
  <Image img="Failure Failure" width="960" />

  <div class="t-10" />
  <h3>An App that will help you on warning yourself.</h3>
  <p>
    Log in to this app daily, watch some <i>motivational videos</i> by Steven He,
    try to keep streak as long as possible, keep doing this until you are admitted
    at your dream school!
  </p>

  <p>Work in Progress</p>
</main>

<style lang="postcss">
  iframe {
    @apply mx-auto;
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

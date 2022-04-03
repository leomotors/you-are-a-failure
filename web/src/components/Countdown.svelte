<script lang="ts">
  import { onMount } from "svelte";

  const releaseDate = new Date("1 Apr 2022 UTC+0");
  let time = "Loading...";

  function a(n: number) {
    return n >= 10 ? `${n}` : `0${n}`;
  }

  function update() {
    let rem = releaseDate.getTime() - new Date().getTime();

    if (rem < 0) return "";

    rem = Math.floor(rem / 1000);

    let sign = "";
    if (rem < 0) {
      sign = "-";
      rem = -rem;
    }

    const s = rem % 60;
    const tm = Math.floor(rem / 60);
    const m = tm % 60;
    const th = Math.floor(tm / 60);
    const h = th % 24;
    const d = Math.floor(th / 24);

    return `${sign}${d}:${a(h)}:${a(m)}:${a(s)}`;
  }

  onMount(() => {
    const interval = setInterval(() => {
      time = update();
    }, 1000);

    return () => clearInterval(interval);
  });
</script>

{#if time}
  <h2 class="font-bold">
    1.0.69 will be released in
    <br />
    {time}
  </h2>
{:else}
  <slot />
{/if}

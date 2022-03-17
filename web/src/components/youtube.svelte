<script lang="ts">
  export let src: string;
</script>

<iframe
  class="mx-auto"
  width="640"
  height="360"
  {src}
  title="YouTube video player"
  frameborder="0"
  allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
  allowfullscreen
/>

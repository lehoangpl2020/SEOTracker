<script setup lang="ts">
    import Tracker from './components/Tracker.vue'
</script>

<template>
    <!--<header>-->
        <!--<img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" />-->

        <!--<div class="wrapper">-->
            <!--<HelloWorld msg="You did it!" />-->
        <!--</div>
    </header>-->

    <main>
        <!--<TheWelcome />-->
        <Tracker/>

    </main>
</template>

<style scoped>
    header {
        line-height: 1.5;
    }

    .logo {
        display: block;
        margin: 0 auto 2rem;
    }

    main {
        display: flex;
        flex-direction: column;
        justify-content: center; /* Vertically center the content */
        align-items: center; /* Horizontally center the content */
        min-height: 100vh; /* Full viewport height */
        max-width: 1200px; /* Maximum width of the container */
        margin: 0 auto; /* Center the container */
        padding: 1rem; /* Optional: some padding inside the container */
    }

    @media (min-width: 1024px) {
        header {
            display: flex;
            place-items: center;
            padding-right: calc(var(--section-gap) / 2);
        }

        .logo {
            margin: 0 2rem 0 0;
        }

        header .wrapper {
            display: flex;
            place-items: flex-start;
            flex-wrap: wrap;
        }
    }
</style>

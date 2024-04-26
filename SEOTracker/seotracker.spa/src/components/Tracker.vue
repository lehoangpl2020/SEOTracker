<template>
    <div class="histories-component">
        <h1>SEO Tracker</h1>
        <div v-if="items" class="content">
            <table>
                <thead>
                    <tr>
                        <th>Search Engine</th>
                        <th>Keywords</th>
                        <th>Positions</th>
                        <th>Url</th>
                        <th>Date</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in items" :key="item.RankRecordId">
                        <td>{{ item.searchEngine }}</td>
                        <td>{{ item.keywords }}</td>
                        <td>{{ item.positions }}</td>
                        <td>{{ item.Url }}</td>
                        <td>{{ item.checkedDate}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    export default defineComponent({
        data() {
            return {
                items: null,
                loading: false
            }
        },
        mounted() {
            this.loadItems();
        },
        methods: {
            loadItems() {
                this.loading = true;
                fetch('https://localhost:7127/history', {
                    method: 'GET',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                }).then(response => response.json())
                    .then(json => {
                        this.items = json;
                    }).finally(() => {
                        this.loading = false;
                    });
            },

        }
    });
</script>

<style scoped>
    h1 {
        font-weight: 500;
        font-size: 2.6rem;
        position: relative;
        top: -10px;
    }

    h3 {
        font-size: 1.2rem;
    }

    .greetings h1,
    .greetings h3 {
        text-align: center;
    }

    @media (min-width: 1024px) {
        .greetings h1,
        .greetings h3 {
            text-align: left;
        }
    }
</style>

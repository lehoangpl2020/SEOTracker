<template>
    <div class="histories-component">
        <h1>SEO Tracker</h1>
        <div class="search">
            <input type="text" v-model="keywords" />
            <input type="text" v-model="url" />
            <button @click="onClickSearch">Search</button>
        </div>

        <div class="search-result">
            <span>{{result}}</span>
        </div>

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
                keywords: 'landing registry searches',
                url: 'www.infotrack.co.uk',
                items: null,
                loading: false,
                result: ''
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
                    }).catch(error => {
                        this.result = 'Failed to load items';
                    });
            },
            onClickSearch() {
                console.log(this.keywords);


            }

        }
    });
</script>

<style scoped>
    .histories-component {
        font-family: 'Open Sans', sans-serif; /* Or any other font from Google Fonts */
        max-width: 960px;
        margin: 40px auto;
        padding: 40px;
        box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        border-radius: 8px;
        background-color: #fff;
    }

    h1 {
        font-size: 2.4rem;
        color: #333;
        margin-bottom: 30px;
    }

    .search {
        display: flex;
        justify-content: space-between;
        margin-bottom: 30px;
    }

    input[type="text"] {
        width: 45%;
        padding: 12px 15px;
        border: 1px solid #ddd;
        border-radius: 4px;
        box-shadow: inset 0 1px 3px rgba(0,0,0,0.1);
        transition: border-color 0.3s;
    }

        input[type="text"]:focus {
            border-color: #5cb85c;
        }

    button {
        padding: 12px 20px;
        background-color: #5cb85c;
        color: white;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        transition: all 0.3s;
        font-weight: bold;
    }

        button:hover, button:focus {
            background-color: #4cae4c;
            box-shadow: 0 2px 4px rgba(0,0,0,0.2);
        }

    table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

    th, td {
        text-align: left;
        padding: 15px;
        border-bottom: 1px solid #eee;
    }

    th {
        background-color: #f9f9f9;
    }

    tr:hover {
        background-color: #f4f4f4; /* Subtle hover effect for table rows */
    }

    .search-result {
        padding: 15px;
        background-color: #f9f9f9;
        border: 1px solid #eee;
        border-radius: 4px;
        margin-bottom: 20px;
    }

    @media (max-width: 768px) {
        .search {
            flex-direction: column;
        }

        input[type="text"], button {
            width: 100%;
            margin-bottom: 15px;
        }
    }
</style>



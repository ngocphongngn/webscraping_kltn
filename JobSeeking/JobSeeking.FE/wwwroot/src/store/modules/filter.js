const state = {
    filter: {
        month: 0,
        year: 0,
        keyword: "",
        declarationStatus: 0,
        taxType: 0,
        deleteMulti: false
    }
}

const mutations = {
    ADD_FILTER: (state, filter) => {
        state.filter = filter;
    },
    ADD_DELETEMULTI: (state, val) => {
        state.filter.deleteMulti = val
    }
}

const actions = {
    addFilter({ commit }, filter) {
        commit('ADD_FILTER', filter)
    },
    addDeleteMulti({commit}, val){
        commit('ADD_DELETEMULTI',val)
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}
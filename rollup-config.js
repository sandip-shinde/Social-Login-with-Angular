import rollup      from 'rollup';
import nodeResolve from 'rollup-plugin-node-resolve';
import commonjs    from 'rollup-plugin-commonjs';
import uglify      from 'rollup-plugin-uglify';

import includePaths from 'rollup-plugin-includepaths';
 
let includePathOptions = {
    include: { 'core-module/core.module' : 'core-module/core.module.js' },
    extensions: ['.js', '.json', '.html']
};

//paths are relative to the execution path
export default {
input: 'app/main-aot.js',
output : {
    file: 'aot/dist/build.js', // output a single application bundle
    format: 'iife'
},
sourcemap: true,
sourcemapFile: 'aot/dist/build.js.map',

plugins: [
    includePaths(includePathOptions),
    nodeResolve({jsnext: true, module: true}),
commonjs({
    include: [
        'core-module/**',
        'app/**',
        'node_modules/rxjs/**',
        'node_modules/angular2-logger/**',
        'node_modules/ng2-bs3-modal/**',
        'node_modules/ng2-cookies/**',
        'node_modules/ng2-toastr/**',
        'node_modules/ng2-translate/**',
        'node_modules/ng2-select/**',
        'node_modules/moment/**'
        
    ],
    namedExports: {
        'node_modules/angular2-logger/core.js': [ 'Logger', 'Options', 'Level' ],            
        'node_modules/ng2-bs3-modal/ng2-bs3-modal.js' : [ 'ModalComponent' ],
        'node_modules/ng2-cookies/ng2-cookies.js': [ 'Cookie' ],
        'node_modules/ng2-select/index.js': [ 'SelectModule', 'SelectComponent' ]        
    }
}),
uglify()
]
}
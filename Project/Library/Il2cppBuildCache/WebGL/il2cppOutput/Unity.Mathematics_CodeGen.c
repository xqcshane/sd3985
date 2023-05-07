#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Int32 Unity.Mathematics.math::asint(System.Single)
extern void math_asint_mA58A5DFF25FB3AF5A3D8705D6BA70B916A2E41E7 (void);
// 0x00000002 System.UInt32 Unity.Mathematics.math::asuint(System.Single)
extern void math_asuint_m5C798CD94D48BA6240ECBB5EFDAD2D565ECDDEE6 (void);
// 0x00000003 System.Single Unity.Mathematics.math::asfloat(System.Int32)
extern void math_asfloat_m0F490C819C7F72ECFEA9B6079E690C72ED5028ED (void);
// 0x00000004 System.Single Unity.Mathematics.math::asfloat(System.UInt32)
extern void math_asfloat_m10F84A2A94E30A6EA7D23F9FCDBCDDB709328684 (void);
// 0x00000005 System.Single Unity.Mathematics.math::abs(System.Single)
extern void math_abs_m9FC1E26CF8BA386EF73BBADB723948F488D6AC86 (void);
static Il2CppMethodPointer s_methodPointers[5] = 
{
	math_asint_mA58A5DFF25FB3AF5A3D8705D6BA70B916A2E41E7,
	math_asuint_m5C798CD94D48BA6240ECBB5EFDAD2D565ECDDEE6,
	math_asfloat_m0F490C819C7F72ECFEA9B6079E690C72ED5028ED,
	math_asfloat_m10F84A2A94E30A6EA7D23F9FCDBCDDB709328684,
	math_abs_m9FC1E26CF8BA386EF73BBADB723948F488D6AC86,
};
static const int32_t s_InvokerIndices[5] = 
{
	3444,
	3444,
	3531,
	3531,
	3535,
};
extern const CustomAttributesCacheGenerator g_Unity_Mathematics_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_Unity_Mathematics_CodeGenModule;
const Il2CppCodeGenModule g_Unity_Mathematics_CodeGenModule = 
{
	"Unity.Mathematics.dll",
	5,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	0,
	NULL,
	0,
	NULL,
	NULL,
	g_Unity_Mathematics_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};

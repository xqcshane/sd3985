#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>






IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_tA96012C582F6417CD28F1C5F72BB7CDE7A2C96C8 
{
public:

public:
};


// System.Object

struct Il2CppArrayBounds;

// System.Array


// System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52  : public RuntimeObject
{
public:

public:
};

// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_com
{
};

// Unity.Mathematics.math
struct math_tFA6CF4319F9BE692A3A01857946865C31AEDED0E  : public RuntimeObject
{
public:

public:
};


// System.Int32
struct Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046 
{
public:
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Int32_tFDE5F8CD43D10453F6A2E0C77FE48C6CC7009046, ___m_value_0)); }
	inline int32_t get_m_value_0() const { return ___m_value_0; }
	inline int32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int32_t value)
	{
		___m_value_0 = value;
	}
};


// System.Single
struct Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E 
{
public:
	// System.Single System.Single::m_value
	float ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Single_tE07797BA3C98D4CA9B5A19413C19A76688AB899E, ___m_value_0)); }
	inline float get_m_value_0() const { return ___m_value_0; }
	inline float* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(float value)
	{
		___m_value_0 = value;
	}
};


// System.UInt32
struct UInt32_tE60352A06233E4E69DD198BCC67142159F686B15 
{
public:
	// System.UInt32 System.UInt32::m_value
	uint32_t ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(UInt32_tE60352A06233E4E69DD198BCC67142159F686B15, ___m_value_0)); }
	inline uint32_t get_m_value_0() const { return ___m_value_0; }
	inline uint32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint32_t value)
	{
		___m_value_0 = value;
	}
};


// Unity.Mathematics.math/IntFloatUnion
struct IntFloatUnion_t3B42C127ECCA706E64B5C2B9EE370A632FC83548 
{
public:
	union
	{
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Int32 Unity.Mathematics.math/IntFloatUnion::intValue
			int32_t ___intValue_0;
		};
		#pragma pack(pop, tp)
		struct
		{
			int32_t ___intValue_0_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Single Unity.Mathematics.math/IntFloatUnion::floatValue
			float ___floatValue_1;
		};
		#pragma pack(pop, tp)
		struct
		{
			float ___floatValue_1_forAlignmentOnly;
		};
	};

public:
	inline static int32_t get_offset_of_intValue_0() { return static_cast<int32_t>(offsetof(IntFloatUnion_t3B42C127ECCA706E64B5C2B9EE370A632FC83548, ___intValue_0)); }
	inline int32_t get_intValue_0() const { return ___intValue_0; }
	inline int32_t* get_address_of_intValue_0() { return &___intValue_0; }
	inline void set_intValue_0(int32_t value)
	{
		___intValue_0 = value;
	}

	inline static int32_t get_offset_of_floatValue_1() { return static_cast<int32_t>(offsetof(IntFloatUnion_t3B42C127ECCA706E64B5C2B9EE370A632FC83548, ___floatValue_1)); }
	inline float get_floatValue_1() const { return ___floatValue_1; }
	inline float* get_address_of_floatValue_1() { return &___floatValue_1; }
	inline void set_floatValue_1(float value)
	{
		___floatValue_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Int32 Unity.Mathematics.math::asint(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t math_asint_mA58A5DFF25FB3AF5A3D8705D6BA70B916A2E41E7_inline (float ___x0, const RuntimeMethod* method);
// System.Single Unity.Mathematics.math::asfloat(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_asfloat_m0F490C819C7F72ECFEA9B6079E690C72ED5028ED_inline (int32_t ___x0, const RuntimeMethod* method);
// System.UInt32 Unity.Mathematics.math::asuint(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t math_asuint_m5C798CD94D48BA6240ECBB5EFDAD2D565ECDDEE6_inline (float ___x0, const RuntimeMethod* method);
// System.Single Unity.Mathematics.math::asfloat(System.UInt32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_asfloat_m10F84A2A94E30A6EA7D23F9FCDBCDDB709328684_inline (uint32_t ___x0, const RuntimeMethod* method);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Int32 Unity.Mathematics.math::asint(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t math_asint_mA58A5DFF25FB3AF5A3D8705D6BA70B916A2E41E7 (float ___x0, const RuntimeMethod* method)
{
	IntFloatUnion_t3B42C127ECCA706E64B5C2B9EE370A632FC83548  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// u.intValue = 0;
		(&V_0)->set_intValue_0(0);
		// u.floatValue = x;
		float L_0 = ___x0;
		(&V_0)->set_floatValue_1(L_0);
		// return u.intValue;
		IntFloatUnion_t3B42C127ECCA706E64B5C2B9EE370A632FC83548  L_1 = V_0;
		int32_t L_2 = L_1.get_intValue_0();
		return L_2;
	}
}
// System.UInt32 Unity.Mathematics.math::asuint(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t math_asuint_m5C798CD94D48BA6240ECBB5EFDAD2D565ECDDEE6 (float ___x0, const RuntimeMethod* method)
{
	{
		// public static uint asuint(float x) { return (uint)asint(x); }
		float L_0 = ___x0;
		int32_t L_1;
		L_1 = math_asint_mA58A5DFF25FB3AF5A3D8705D6BA70B916A2E41E7_inline(L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.Single Unity.Mathematics.math::asfloat(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float math_asfloat_m0F490C819C7F72ECFEA9B6079E690C72ED5028ED (int32_t ___x0, const RuntimeMethod* method)
{
	IntFloatUnion_t3B42C127ECCA706E64B5C2B9EE370A632FC83548  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// u.floatValue = 0;
		(&V_0)->set_floatValue_1((0.0f));
		// u.intValue = x;
		int32_t L_0 = ___x0;
		(&V_0)->set_intValue_0(L_0);
		// return u.floatValue;
		IntFloatUnion_t3B42C127ECCA706E64B5C2B9EE370A632FC83548  L_1 = V_0;
		float L_2 = L_1.get_floatValue_1();
		return L_2;
	}
}
// System.Single Unity.Mathematics.math::asfloat(System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float math_asfloat_m10F84A2A94E30A6EA7D23F9FCDBCDDB709328684 (uint32_t ___x0, const RuntimeMethod* method)
{
	{
		// public static float  asfloat(uint x) { return asfloat((int)x); }
		uint32_t L_0 = ___x0;
		float L_1;
		L_1 = math_asfloat_m0F490C819C7F72ECFEA9B6079E690C72ED5028ED_inline(L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
// System.Single Unity.Mathematics.math::abs(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float math_abs_m9FC1E26CF8BA386EF73BBADB723948F488D6AC86 (float ___x0, const RuntimeMethod* method)
{
	{
		// public static float abs(float x) { return asfloat(asuint(x) & 0x7FFFFFFF); }
		float L_0 = ___x0;
		uint32_t L_1;
		L_1 = math_asuint_m5C798CD94D48BA6240ECBB5EFDAD2D565ECDDEE6_inline(L_0, /*hidden argument*/NULL);
		float L_2;
		L_2 = math_asfloat_m10F84A2A94E30A6EA7D23F9FCDBCDDB709328684_inline(((int32_t)((int32_t)L_1&(int32_t)((int32_t)2147483647LL))), /*hidden argument*/NULL);
		return L_2;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t math_asint_mA58A5DFF25FB3AF5A3D8705D6BA70B916A2E41E7_inline (float ___x0, const RuntimeMethod* method)
{
	IntFloatUnion_t3B42C127ECCA706E64B5C2B9EE370A632FC83548  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// u.intValue = 0;
		(&V_0)->set_intValue_0(0);
		// u.floatValue = x;
		float L_0 = ___x0;
		(&V_0)->set_floatValue_1(L_0);
		// return u.intValue;
		IntFloatUnion_t3B42C127ECCA706E64B5C2B9EE370A632FC83548  L_1 = V_0;
		int32_t L_2 = L_1.get_intValue_0();
		return L_2;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_asfloat_m0F490C819C7F72ECFEA9B6079E690C72ED5028ED_inline (int32_t ___x0, const RuntimeMethod* method)
{
	IntFloatUnion_t3B42C127ECCA706E64B5C2B9EE370A632FC83548  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// u.floatValue = 0;
		(&V_0)->set_floatValue_1((0.0f));
		// u.intValue = x;
		int32_t L_0 = ___x0;
		(&V_0)->set_intValue_0(L_0);
		// return u.floatValue;
		IntFloatUnion_t3B42C127ECCA706E64B5C2B9EE370A632FC83548  L_1 = V_0;
		float L_2 = L_1.get_floatValue_1();
		return L_2;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t math_asuint_m5C798CD94D48BA6240ECBB5EFDAD2D565ECDDEE6_inline (float ___x0, const RuntimeMethod* method)
{
	{
		// public static uint asuint(float x) { return (uint)asint(x); }
		float L_0 = ___x0;
		int32_t L_1;
		L_1 = math_asint_mA58A5DFF25FB3AF5A3D8705D6BA70B916A2E41E7_inline(L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_asfloat_m10F84A2A94E30A6EA7D23F9FCDBCDDB709328684_inline (uint32_t ___x0, const RuntimeMethod* method)
{
	{
		// public static float  asfloat(uint x) { return asfloat((int)x); }
		uint32_t L_0 = ___x0;
		float L_1;
		L_1 = math_asfloat_m0F490C819C7F72ECFEA9B6079E690C72ED5028ED_inline(L_0, /*hidden argument*/NULL);
		return L_1;
	}
}
